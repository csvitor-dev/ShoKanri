using System;
using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Repositories.Transactions;

public class TransactionWriteRepository : ITransactionWriteRepository
{
    private readonly AppDbContext _context;

    public TransactionWriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Transaction entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Transaction transaction = await _context.Set<Transaction>().FirstOrDefaultAsync(t => t.Id == id) ??
                                  throw new InvalidOperationException("No transaction with this id");
        _context.Remove(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Transaction entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
