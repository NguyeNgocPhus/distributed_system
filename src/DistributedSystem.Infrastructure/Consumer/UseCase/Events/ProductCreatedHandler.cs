using DistributedSystem.Contract.Abstractions.Messages;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Product;
using DistributedSystem.Infrastructure.Consumer.Abstractions.Repositories;
using DistributedSystem.Infrastructure.Consumer.Models;

namespace DistributedSystem.Infrastructure.Consumer.UseCase.Events;

public class ProductCreatedHandler : ICommandHandler<DomainEvent.ProductCreated>
{
    private readonly IMongoRepository<ProductProjection> _mongoRepository;

    public ProductCreatedHandler(IMongoRepository<ProductProjection> mongoRepository)
    {
        _mongoRepository = mongoRepository;
    }

    public async Task<Result> Handle(DomainEvent.ProductCreated request, CancellationToken cancellationToken)
    {
        var product = new ProductProjection()
        {
            Name = request.Name,
            Price = request.Price,
            Description = request.Description,
            DocumentId = request.Id.ToString(),
            CreatedAt = DateTimeOffset.Now,
            
        };
        await _mongoRepository.InsertOneAsync(product);

        return Result.Success();
    }
}