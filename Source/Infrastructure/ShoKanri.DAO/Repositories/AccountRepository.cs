using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories;
using ShoKanri.Domain.Entities;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Repositories;

public class AccountRepository(AppDbContext _context) : BaseRepository<Account>(_context), IAccountRepository
{
    public async Task<IList<Transaction>?> FindStatementForAccountAsync(int accountId)
    {
        Account account = await FindByIdAsync(accountId) ??
                          throw new InvalidOperationException("account not found");

        return account.Statement;
    }
    public async Task CreateTransactionForAccount(int accountId, Transaction transaction)
    {
        Account account = await FindByIdAsync(accountId) ??
                          throw new InvalidOperationException("Id for entry inexistent, try another");

        transaction.Execute(account);

        await UpdateAsync(account);
    }
}
