using System;
using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories.Base;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Repositories;

public class BaseRepository<T>(AppDbContext context) : IWriteOnlyRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context = context;
    
    public async Task CreateAsync(T entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        T entity = await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id) ??
                   throw new InvalidOperationException("Id for entry inexistent, try another");

        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
