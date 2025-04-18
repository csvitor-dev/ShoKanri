using ShoKanri.Domain.Contracts.Data.Repositories.Base;

namespace ShoKanri.Domain.Contracts.Data.Repositories.Account;

public interface IAccountWriteRepository 
    : IWriteOnlyRepository<Entities.Account>
{
    Task CreateTransactionForAccountAsync(int accountId, Entities.Transactions.Transaction transaction);
}

