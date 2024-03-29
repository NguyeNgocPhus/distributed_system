﻿using DistributedSystem.Contract.Abstractions.Messages;
using DistributedSystem.Domain.Abstractions.Entities;

namespace DistributedSystem.Domain.Abstractions.Aggregates;

public abstract class AggregateRoot<T> : Entity<T>
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent domainEvent) =>
        _domainEvents.Add(domainEvent);
}