using System.Linq.Expressions;

namespace Framework.Domain;

public interface IRepository<T> where T : IAggregateRoot
{
    Task<T> AddAsync
        (T entity, CancellationToken cancellationToken = default);

    Task AddRangeAsync
        (IEnumerable<T> entities, CancellationToken cancellationToken = default);

    void Update(T entity);

    Task<IEnumerable<T>> SelectAsync
        (Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    Task<T> FindAsync
        (long id, CancellationToken cancellationToken = default);

    Task<int> SaveAsync
        (CancellationToken cancellationToken = default(CancellationToken));

}