using DistributedSystem.Contract.Abstractions.Shared;
using MassTransit;
using MediatR;

namespace DistributedSystem.Contract.Abstractions.Messages;
[ExcludeFromTopology]
public interface ICommand : IRequest<Result>
{
}
[ExcludeFromTopology]
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
