using DistributedSystem.Contract.Services.V1.Product;
using DistributedSystem.Infrastructure.Consumer.Abstractions.Messages;
using DistributedSystem.Infrastructure.Consumer.Abstractions.Repositories;
using DistributedSystem.Infrastructure.Consumer.Models;
using MediatR;

namespace DistributedSystem.Infrastructure.Consumer.MessageBus.Events;

public class ProductUpdatedConsumer: Consumer<DomainEvent.ProductUpdated>
{
    public ProductUpdatedConsumer(ISender sender, IMongoRepository<EventProjection> mongoRepository) : base(sender, mongoRepository)
    {
    }
}