using System;
using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Entities;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Repositories.Accounts;

public class AccountWriteRepository : IAccountWriteRepository
{
    private readonly AppDbContext _context;

    public AccountWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(Account entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task CreateTransactionForAccount(int accountId, Transaction transaction)
    {
        Account account = await _context.Set<Account>().FirstOrDefaultAsync(a => a.Id == accountId) ??
                          throw new InvalidOperationException("Account not found");

        account.RegisterTransaction(transaction);
        await UpdateAsync(account);
    }

    public async Task DeleteAsync(int id)
    {
        Account account = await _context.Set<Account>().FirstOrDefaultAsync(a => a.Id == id) ??
                          throw new InvalidOperationException("Account not found");

        _context.Remove(account);
        await _context.SaveChangesAsync();

    }

    public async Task UpdateAsync(Account entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
