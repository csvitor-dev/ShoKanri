using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}
