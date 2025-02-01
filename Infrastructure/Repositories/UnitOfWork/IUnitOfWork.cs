namespace Infrastructure.Repositories.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable, IDisposable
{
    public Task<int> CommitAsync();
    public int Commit();
}