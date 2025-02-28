namespace ShoKanri.Domain.Contracts.Data.Services;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken token = default);
}