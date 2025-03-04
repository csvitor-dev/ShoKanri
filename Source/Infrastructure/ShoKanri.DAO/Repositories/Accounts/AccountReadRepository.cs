using System;
using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Entities;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Repositories.Accounts;

public class AccountReadRepository : IAccountReadRepository
{
    private readonly AppDbContext _context;

    public AccountReadRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Domain.Entities.Account>> FindAllAsync()
    {
        return await _context.Set<Account>().ToListAsync();
    }

    public async Task<Domain.Entities.Account?> FindByIdAsync(int id)
    {
        return await _context.Set<Account>().FirstOrDefaultAsync(u => u.Id == id);
    }

    //Ask about this method
    public async Task<IList<Transaction>?> FindStatementForAccountAsync(int accountId)
    {
        Account account = await FindByIdAsync(accountId) ??
                          throw new InvalidOperationException("account not found");

        return account.Statement;
    }
}
