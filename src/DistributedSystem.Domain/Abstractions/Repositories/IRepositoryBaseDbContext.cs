using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DistributedSystem.Domain.Abstractions.Entities;

namespace DistributedSystem.Domain.Abstractions.Repositories;

public interface IRepositoryBaseDbContext<TContext, TEntity, in TKey>
    where TContext : DbContext
    where TEntity : Entity<TKey> // => In implementation should be Entity<TKey>
{
    Task<TEntity> FindByIdAsync(TKey id, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties);

    Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default, params Expression<Func<TEntity, object>>[] includeProperties);

    IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);

    void Add(TEntity entity);

    void Update(TEntity entity);

    void Remove(TEntity entity);

    void RemoveMultiple(List<TEntity> entities);
}