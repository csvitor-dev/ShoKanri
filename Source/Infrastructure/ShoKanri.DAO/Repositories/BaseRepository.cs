using System;
using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories.Base;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Repositories;

public class BaseRepository<T>(AppDbContext context) :
IReadOnlyRepository<T>, IWriteOnlyRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context = context;

    public async Task<IList<T>> FindAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> FindByIdAsync(int id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task CreateAsync(T entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        T entity = await FindByIdAsync(id) ??
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
