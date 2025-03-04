using System;
using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Repositories.Transactions;

public class TransactionReadRepository : ITransactionReadRepository
{
    private readonly AppDbContext _context;

    public TransactionReadRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transaction>> FindAllAsync()
    {
        return await _context.Set<Transaction>().ToListAsync();
    }

    public async Task<Transaction?> FindByIdAsync(int id)
    {
        return await _context.Set<Transaction>().FirstOrDefaultAsync(t => t.Id == id);
    }
}
