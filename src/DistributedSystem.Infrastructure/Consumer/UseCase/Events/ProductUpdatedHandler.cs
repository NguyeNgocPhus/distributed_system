using DistributedSystem.Contract.Abstractions.Messages;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Product;

namespace DistributedSystem.Infrastructure.Consumer.UseCase.Events;

public class ProductUpdatedHandler : ICommandHandler<DomainEvent.ProductUpdated>
{
    public async Task<Result> Handle(DomainEvent.ProductUpdated request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return Result.Success();
    }
}