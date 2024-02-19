using MediatR;

namespace DistributedSystem.Contract.Abstractions.Messages;

public interface IDomainEvent  : INotification
{
    public Guid IdEvent { get; init; }
}
