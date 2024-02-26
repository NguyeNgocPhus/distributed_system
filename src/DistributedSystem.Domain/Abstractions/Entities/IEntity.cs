namespace DistributedSystem.Domain.Abstractions.Entities;

public interface IEntity<T>
{
    public T Id { get; protected set; }
    public bool IsDeleted { get; protected set; }
}