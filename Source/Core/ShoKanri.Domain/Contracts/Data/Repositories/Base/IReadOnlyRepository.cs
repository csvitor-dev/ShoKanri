using ShoKanri.Domain.Entities;

namespace ShoKanri.Domain.Contracts.Data.Repositories.Base;

public interface IReadOnlyRepository<T> where T : BaseEntity
{
    Task<IList<T>> FindAllAsync(int wrapperId);
        Task<T?> FindByIdAsync(int entityId, int wrapperId);
}
