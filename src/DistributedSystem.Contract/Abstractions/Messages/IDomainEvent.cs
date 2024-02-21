using MassTransit;

namespace DistributedSystem.Contract.Abstractions.Messages;

[ExcludeFromTopology]
public interface IDomainEvent  
{
    public Guid IdEvent { get; init; }
}
