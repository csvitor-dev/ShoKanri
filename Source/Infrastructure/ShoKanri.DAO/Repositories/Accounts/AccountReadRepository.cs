using System;
using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.DAO.Repositories.Base;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Entities;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Repositories.Accounts;

public class AccountReadRepository(AppDbContext context) : ReadOnlyRepository<Account>(context), IAccountReadRepository
{
    //Ask about this method
    public async Task<IList<Transaction>?> FindStatementForAccountAsync(int accountId)
    {
        Account account = await FindByIdAsync(accountId) ??
                          throw new InvalidOperationException("account not found");

        return account.Statement;
    }
}
