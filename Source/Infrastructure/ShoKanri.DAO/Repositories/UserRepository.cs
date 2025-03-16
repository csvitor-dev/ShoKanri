using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Repositories;

public class UserRepository(AppDbContext _context) : BaseRepository<User>(_context),
IUserReadRepository, IUserWriteRepository
{
    public Task DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> FindActiveEmailAsync(string email)
    {
        return await _context.Set<User>().AnyAsync(u => u.Email == email);
    }

    public async Task<User?> FindByIdAsync(int id)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
    }
}
