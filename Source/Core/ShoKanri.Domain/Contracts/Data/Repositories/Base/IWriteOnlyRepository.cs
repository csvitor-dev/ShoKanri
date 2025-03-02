using ShoKanri.Domain.Entities;

namespace ShoKanri.Domain.Contracts.Data.Repositories.Base;

public interface IWriteOnlyRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}