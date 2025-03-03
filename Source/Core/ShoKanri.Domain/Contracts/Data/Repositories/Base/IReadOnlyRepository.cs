using ShoKanri.Domain.Entities;

namespace ShoKanri.Domain.Contracts.Data.Repositories.Base;

public interface IReadOnlyRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> FindAllAsync();
    Task<T?> FindByIdAsync(int id);
}
