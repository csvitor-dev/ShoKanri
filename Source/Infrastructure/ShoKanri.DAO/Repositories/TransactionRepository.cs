using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Repositories;

public class TransactionRepository(AppDbContext _context) : BaseRepository<Transaction>(_context),
ITransactionReadRepository, ITransactionWriteRepository
{
    public async Task<IList<Transaction>> FindAllAsync(int accountId)
    {
        return await _context.Set<Transaction>().Where(t => t.AccountId == accountId).ToListAsync();
    }

    public async Task<Transaction?> FindByIdAsync(int transactionId, int accountId)
    {
        return await _context.Set<Transaction>().FirstOrDefaultAsync(t => t.Id == transactionId && t.AccountId == accountId);
    }
}
