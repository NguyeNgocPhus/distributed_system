using DistributedSystem.Contract.Abstractions.Shared;
using MediatR;

namespace DistributedSystem.Contract.Abstractions.Messages;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{ }
