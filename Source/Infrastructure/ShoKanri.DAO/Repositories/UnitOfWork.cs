using System;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Services;

namespace ShoKanri.DAO.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
