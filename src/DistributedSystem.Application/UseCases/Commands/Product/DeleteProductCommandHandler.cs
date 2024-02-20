using DistributedSystem.Contract.Abstractions.Messages;
using DistributedSystem.Contract.Abstractions.Shared;
using DistributedSystem.Contract.Services.V1.Product;
using Microsoft.EntityFrameworkCore;

namespace DistributedSystem.Application.UseCases.Commands.Product;

public class DeleteProductCommandHandler: ICommandHandler<Command.DeleteProductCommand>
{
    public async Task<Result> Handle(Command.DeleteProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}