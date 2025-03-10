using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Repositories;

public class UserRepository(AppDbContext _context) : BaseRepository<User>(_context), IUserRepository
{
    public async Task<bool> FindActiveEmailAsync(string email)
    {
        return await _context.Set<User>().AnyAsync(u => u.Email == email);
    }
}
