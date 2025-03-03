using ShoKanri.Domain.Contracts.Data.Repositories.Base;

namespace ShoKanri.Domain.Contracts.Data.Repositories.Account;

public interface IAccountReadRepository : IReadOnlyRepository<Entities.Account>
{
    Task<IEnumerable<Entities.Transactions.Transaction>?> FindStatementForAccountAsync(int accountId);
}
