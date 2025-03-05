using System;
using Microsoft.EntityFrameworkCore;
using ShoKanri.DAO.Context;
using ShoKanri.DAO.Repositories.Base;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Repositories.Users;

public class UserReadRepository(AppDbContext _context) : ReadOnlyRepository<User>(_context), IUserReadRepository
{
    public async Task<bool> FindActiveEmailAsync(string email)
    {
        return await _context.Set<User>().AnyAsync(u => u.Email == email);
    }
}
