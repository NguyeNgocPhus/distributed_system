using DistributedSystem.Contract.Abstractions.Messages;
using DistributedSystem.Contract.Services.V1.Product;
using DistributedSystem.Persistence;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;

namespace DistributedSystem.Infrastructure.BackgroundJob;

[DisallowConcurrentExecution]
public class ProcessOutboxMessageJob : IJob
{
    private readonly ApplicationDbContext _dbContext;

    private readonly IPublishEndpoint _publish;

    public ProcessOutboxMessageJob(IPublishEndpoint publish, ApplicationDbContext dbContext)
    {
        _publish = publish;
        _dbContext = dbContext;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var outboxMessages = await _dbContext.OutboxMessages.Where(x => x.ProcessOnUtc == null)
            .OrderBy(x => x.OccurredOnUtc)
            .Take(20)
            .ToListAsync();

        foreach (var outboxMessage in outboxMessages)
        {
            try
            {
                var content = outboxMessage.Content;
                var domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(content, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
                if (domainEvent == null)
                {
                    continue;
                }
                switch (domainEvent.GetType().Name)
                {
                    case nameof(DomainEvent.ProductCreated):
                        var messageCreated =  JsonConvert.DeserializeObject<DomainEvent.ProductCreated>(content, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All
                        });
                        await _publish.Publish(messageCreated, context.CancellationToken);
                        break;
                    case nameof(DomainEvent.ProductUpdated):
                        var messageUpdated =  JsonConvert.DeserializeObject<DomainEvent.ProductUpdated>(content, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All
                        });
                        await _publish.Publish(messageUpdated, context.CancellationToken);
                        break;
                    case nameof(DomainEvent.ProductDeleted):
                        var messageDeleted =  JsonConvert.DeserializeObject<DomainEvent.ProductDeleted>(content, new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All
                        });
                        await _publish.Publish(messageDeleted, context.CancellationToken);
                        break;
                
                }
                outboxMessage.ProcessOnUtc = DateTime.Now;

            }
            catch (Exception e)
            {
                outboxMessage.Error = e.Message;
            }

        }

        await _dbContext.SaveChangesAsync();
    }
}