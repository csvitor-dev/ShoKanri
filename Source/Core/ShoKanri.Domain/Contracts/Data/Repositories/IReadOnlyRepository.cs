using ShoKanri.Domain.Entities;

namespace ShoKanri.Domain.Contracts.Data.Repositories;

public interface IReadOnlyRepository<T> where T : BaseEntity
{
    Task<T> FindAllAsync(CancellationToken token = default);
    Task<T> FindByIdAsync(int id, CancellationToken token = default);
}