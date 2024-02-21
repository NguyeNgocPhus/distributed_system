using DistributedSystem.Contract.Services.V1.Product;
using DistributedSystem.Infrastructure.Consumer.Abstractions.Messages;
using MediatR;

namespace DistributedSystem.Infrastructure.Consumer.MessageBus.Events;

public class ProductUpdatedConsumer: Consumer<DomainEvent.ProductUpdated>
{
    public ProductUpdatedConsumer(ISender sender) : base(sender)
    {
    }
}