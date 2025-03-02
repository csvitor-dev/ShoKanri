using System;
using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Repositories.Users;

public class UserWriteRepository : IUserWriteRepository
{
    private readonly AppDbContext _context;

    public UserWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(User entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        User user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id) ??
                    throw new InvalidOperationException("That is no user with this id");

        _context.Remove(user);
        await _context.SaveChangesAsync();
        
    }

    public async Task UpdateAsync(User entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
