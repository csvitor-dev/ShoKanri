using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.DAO.Repositories.Base;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Entities;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Repositories.Accounts;

public class AccountWriteRepository(AppDbContext _context) : WriteOnlyRepository<Account>(_context), IAccountWriteRepository
{
    public async Task CreateTransactionForAccount(int accountId, Transaction transaction)
    {
        Account account = await _context.Set<Account>().FirstOrDefaultAsync(a => a.Id == accountId) ??
                          throw new InvalidOperationException("Id for entry inexistent, try another");

        transaction.Execute(account);

        await UpdateAsync(account);
    }
}
