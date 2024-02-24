using DistributedSystem.Contract.Abstractions.Messages;
using DistributedSystem.Infrastructure.Consumer.Abstractions.Repositories;
using DistributedSystem.Infrastructure.Consumer.Models;
using MassTransit;
using MediatR;

namespace DistributedSystem.Infrastructure.Consumer.Abstractions.Messages;

public abstract class Consumer<TMessage> : IConsumer<TMessage>
where TMessage : class, IDomainEvent
{
    private readonly ISender _sender;
    private readonly IMongoRepository<EventProjection> _mongoRepository;

    protected Consumer(ISender sender, IMongoRepository<EventProjection> mongoRepository)
    {
        _sender = sender;
        _mongoRepository = mongoRepository;
    }
    
    public async Task Consume(ConsumeContext<TMessage> context)
    {
        var @event = await _mongoRepository.FindOneAsync(x => x.EventId == context.Message.IdEvent);
        if (@event is null)
        {
            await _sender.Send(context.Message, context.CancellationToken);
            @event = new EventProjection()
            {
                EventId = context.Message.IdEvent,
                Name = context.Message.GetType().Name,
                Type = context.Message.GetType().Name,
                CreatedAt = DateTimeOffset.Now,

            };
            await _mongoRepository.InsertOneAsync(@event);
            
        }
    }
}