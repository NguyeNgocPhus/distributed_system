namespace DistributedSystem.Domain.Abstractions.Entities;

public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; }
    public bool IsDeleted { get; set; }
}

//public abstract class DomainEntity<T> : IEntity<T>
//{
//    public T Id { get; protected set; }
//}