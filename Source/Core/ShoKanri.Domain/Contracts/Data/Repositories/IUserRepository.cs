using ShoKanri.Domain.Contracts.Data.Repositories.Base;
using ShoKanri.Domain.Entities;

namespace ShoKanri.Domain.Contracts.Data.Repositories;

public interface IUserRepository
    : IWriteOnlyRepository<User>, IReadOnlyRepository<User>
{
    Task<bool> FindActiveEmailAsync(string email);
}