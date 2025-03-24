using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Entities;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Repositories;

public class AccountRepository(AppDbContext _context) : BaseRepository<Account>(_context),
IAccountReadRepository, IAccountWriteRepository
{
    public async Task<IList<Account>> FindAllAsync(int userId)
    {
        return await _context.Set<Account>().Where(a => a.UserId == userId).ToListAsync();
    }

    public async Task<Account?> FindByIdAsync(int entityId, int wrapperId)
    {
        return await _context.Set<Account>().FirstOrDefaultAsync(a => a.Id == entityId && a.UserId == wrapperId);
    }
    public async Task<IList<Transaction>?> FindStatementForAccountAsync(int accountId)
    {
        Account account = await _context.Set<Account>().FirstOrDefaultAsync(a => a.Id == accountId) ??
                          throw new InvalidOperationException("account not found");

        return account.Statement;
    }
    public async Task CreateTransactionForAccountAsync(int accountId, Transaction transaction)
    {
        Account account = await _context.Set<Account>().FirstOrDefaultAsync(a => a.Id == accountId) ??
                          throw new InvalidOperationException("Id for entry inexistent, try another");

        transaction.Execute(account);

        await UpdateAsync(account);
    }
}
