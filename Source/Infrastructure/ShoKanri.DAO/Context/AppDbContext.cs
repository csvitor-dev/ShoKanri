using System;
using System.Transactions;
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
        modelBuilder.Entity<Domain.Entities.Transactions.Transaction>()
            .HasDiscriminator<int>("MovimentKind")
            .HasValue<Income>(0)
            .HasValue<Expense>(1)
            .HasValue<Transference>(2);

        base.OnModelCreating(modelBuilder);
    }
}
