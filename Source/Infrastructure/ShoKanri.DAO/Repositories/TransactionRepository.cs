using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;

namespace ShoKanri.DAO.Repositories.Transactions;

public class TransactionRepository(AppDbContext context) :
ITransactionReadRepository, ITransactionWriteRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<List<Domain.Entities.Transactions.Transaction>> FindAllAsync()
    {
        return await _context.Set<Domain.Entities.Transactions.Transaction>().ToListAsync();
    }

    public async Task<Domain.Entities.Transactions.Transaction?> FindByIdAsync(int id)
    {
        return await _context.Set<Domain.Entities.Transactions.Transaction>().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateAsync(Domain.Entities.Transactions.Transaction entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task CreateAsync(Domain.Entities.Transactions.Transaction entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Domain.Entities.Transactions.Transaction transaction = await FindByIdAsync(id) ??
                                                               throw new InvalidOperationException("No transaction with this id");
        _context.Remove(transaction);
        await _context.SaveChangesAsync();
    }
}
