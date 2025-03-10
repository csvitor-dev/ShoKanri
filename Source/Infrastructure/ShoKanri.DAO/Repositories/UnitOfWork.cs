using System;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Services;

namespace ShoKanri.DAO.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public async Task CommitAsync()
        => await _context.SaveChangesAsync();
}
