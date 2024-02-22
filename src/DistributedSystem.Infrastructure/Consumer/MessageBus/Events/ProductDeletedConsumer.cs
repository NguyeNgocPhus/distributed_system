
using DistributedSystem.Contract.Services.V1.Product;
using DistributedSystem.Infrastructure.Consumer.Abstractions.Messages;
using MediatR;


namespace DistributedSystem.Infrastructure.Consumer.MessageBus.Events;

public class ProductDeletedConsumer: Consumer<DomainEvent.ProductDeleted>
{
    public ProductDeletedConsumer(ISender sender) : base(sender)
    {
    }
}