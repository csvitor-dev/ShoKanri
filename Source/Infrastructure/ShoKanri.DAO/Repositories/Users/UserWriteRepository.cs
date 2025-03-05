using ShoKanri.DAO.Context;
using ShoKanri.DAO.Repositories.Base;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Repositories.Users;

public class UserWriteRepository(AppDbContext _context) : WriteOnlyRepository<User>(_context), IUserWriteRepository
{}
