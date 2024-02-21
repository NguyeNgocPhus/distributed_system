
using DistributedSystem.Infrastructure.Consumer.Abstractions.Messages;
using MediatR;
using DomainEvent = DistributedSystem.Contract.Services.V1.Product.DomainEvent;


namespace DistributedSystem.Infrastructure.Consumer.MessageBus.Events;

public class ProductDeletedConsumer: Consumer<DomainEvent.ProductUpdated>
{
    public ProductDeletedConsumer(ISender sender) : base(sender)
    {
    }
}