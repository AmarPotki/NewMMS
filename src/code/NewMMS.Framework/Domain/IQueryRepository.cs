using System.Linq.Expressions;

namespace Framework.Domain
{
    public interface IQueryRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> SelectAsync
            (Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<T> FindAsync(long id,CancellationToken cancellationToken = default);
    }
}
