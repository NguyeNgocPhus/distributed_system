
using DistributedSystem.Contract.Services.V1.Product;
using DistributedSystem.Infrastructure.Consumer.Abstractions.Messages;
using DistributedSystem.Infrastructure.Consumer.Abstractions.Repositories;
using DistributedSystem.Infrastructure.Consumer.Models;
using MediatR;


namespace DistributedSystem.Infrastructure.Consumer.MessageBus.Events;

public class ProductDeletedConsumer: Consumer<DomainEvent.ProductDeleted>
{
    public ProductDeletedConsumer(ISender sender, IMongoRepository<EventProjection> mongoRepository) : base(sender, mongoRepository)
    {
    }
}