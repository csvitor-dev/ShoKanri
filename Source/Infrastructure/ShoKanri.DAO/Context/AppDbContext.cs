using Microsoft.EntityFrameworkCore;
using ShoKanri.Domain.Entities;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<Transference> Transferences { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().Property(u => u.Active)
                                   .HasConversion<int>();

        modelBuilder.Entity<Account>().HasKey(a => a.Id);
        modelBuilder.Entity<Account>().Property(a => a.Active)
                                      .HasConversion<int>();

        modelBuilder.Entity<Transaction>().HasKey(t => t.Id);

    }
}

