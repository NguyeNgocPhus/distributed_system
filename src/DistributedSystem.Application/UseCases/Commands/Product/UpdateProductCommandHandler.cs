using DistributedSystem.Contract.Abstractions.Messages;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Product;

namespace DistributedSystem.Application.UseCases.Commands.Product;

public class UpdateProductCommandHandler : ICommandHandler<Command.UpdateProductCommand>
{
    public async Task<Result> Handle(Command.UpdateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}