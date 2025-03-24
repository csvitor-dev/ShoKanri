using System;
using System.Threading.Tasks;
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
        await _context.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id) ??
                     throw new InvalidOperationException("Id for entry nonexistent, try another");

        _context.Remove(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        await Task.FromResult(_context.Update(entity));
    }
}
