using DistributedSystem.Contract.Services.V1.Product;
using DistributedSystem.Infrastructure.Consumer.Abstractions.Messages;
using MediatR;

namespace DistributedSystem.Infrastructure.Consumer.MessageBus.Events;

public class ProductCreatedConsumer : Consumer<DomainEvent.ProductCreated>
{
    public ProductCreatedConsumer(ISender sender) : base(sender)
    {
    }
}