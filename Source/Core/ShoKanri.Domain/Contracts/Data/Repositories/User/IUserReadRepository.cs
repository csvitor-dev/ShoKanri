using ShoKanri.Domain.Contracts.Data.Repositories.Base;

namespace ShoKanri.Domain.Contracts.Data.Repositories.User;

public interface IUserReadRepository : IReadOnlyRepository<Entities.User>
{
    Task<bool> FindActiveEmailAsync(string email);
}