using System;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Services;

namespace ShoKanri.DAO.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync()
        => await context.SaveChangesAsync();
}
