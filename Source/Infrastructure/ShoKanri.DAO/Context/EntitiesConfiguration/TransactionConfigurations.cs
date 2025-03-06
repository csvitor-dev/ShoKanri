using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Context.EntitiesConfiguration;

public class TransactionConfigurations : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.CreatedOn)
               .IsRequired()
               .HasColumnType("DATETIME");

        builder.HasDiscriminator<int>("MovementKind")
               .HasValue<Income>(0)
               .HasValue<Expense>(1)
               .HasValue<Transference>(2);
        
       /* builder.HasOne(t => t.Account)
              .WithMany(a = > a.Statement)
              .HasForeignKey(a => a.AccountId); */

       builder.Property(t => t.Amount)
              .IsRequired()
              .HasColumnType("DECIMAL(18, 2)");
    }
}
