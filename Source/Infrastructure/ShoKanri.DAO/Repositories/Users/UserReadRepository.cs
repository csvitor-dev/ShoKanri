using System;
using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Repositories.Users;

public class UserReadRepository : IUserReadRepository
{
    private readonly AppDbContext _context;

    public UserReadRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> FindActiveEmailAsync(string email)
    {
        return await _context.Set<User>().AnyAsync(u => u.Email == email);
    }

    public async Task<List<User>> FindAllAsync()
    {
        return await _context.Set<User>().ToListAsync();
    }

    public async Task<User?> FindByIdAsync(int id)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
    }
}
