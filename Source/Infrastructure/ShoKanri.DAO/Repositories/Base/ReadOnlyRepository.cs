using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Repositories.Base;

public class ReadOnlyRepository<T>(AppDbContext context) : Domain.Contracts.Data.Repositories.Base.IReadOnlyRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context = context;

    public async Task<List<T>> FindAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> FindByIdAsync(int id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
    }
}
