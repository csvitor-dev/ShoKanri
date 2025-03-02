using System;
using Microsoft.EntityFrameworkCore;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<User> Users { get; set; }
}
