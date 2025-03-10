using ShoKanri.Domain.Contracts.Data.Repositories.Base;
using ShoKanri.Domain.Entities;

namespace ShoKanri.Domain.Contracts.Data.Repositories;

public interface IAccountRepository
    : IWriteOnlyRepository<Account>, IReadOnlyRepository<Account>
{
    Task CreateTransactionForAccount(int accountId, Entities.Transactions.Transaction transaction);
    Task<IList<Entities.Transactions.Transaction>?> FindStatementForAccountAsync(int accountId);
}