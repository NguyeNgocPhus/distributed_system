using DistributedSystem.Persistence;
using MassTransit;
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
        await Task.CompletedTask;
    }
}