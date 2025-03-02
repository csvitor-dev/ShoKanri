using ShoKanri.Domain.Contracts.Data.Repositories.Base;

namespace ShoKanri.Domain.Contracts.Data.Repositories.Account;

public interface IAccountReadRepository : IReadOnlyRepository<Entities.Account>
{
    Task<IList<Entities.Transactions.Transaction>?> FindStatementForAccountAsync(int accountId);
}