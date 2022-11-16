namespace Framework.Domain
{
    public interface IBaseUnitOfWork : IDisposable
    {
		bool IsDisposed { get; }

        Task<int> SaveAsync
            (CancellationToken cancellationToken = default);
    }
}