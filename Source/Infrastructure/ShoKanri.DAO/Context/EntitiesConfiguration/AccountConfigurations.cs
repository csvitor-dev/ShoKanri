using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Context.EntitiesConfiguration;

public class AccountConfigurations : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
       builder.HasKey(a => a.Id);

       builder.Property(a => a.Active)
              .IsRequired()
              .HasColumnType("TINYINT");

       builder.Property(a => a.CreatedOn)
              .IsRequired()
              .HasColumnType("DATETIME");

       builder.Property(a => a.UpdatedOn)
              .IsRequired()
              .HasColumnType("DATETIME");

       /* builder.HasOne(a => a.User)
              .WithMany(u => u.Accounts)
              .HasForeignKey(a => a.UserId); */

       builder.Property(a => a.Name)
              .IsRequired()
              .HasColumnType("VARCHAR(255)");

       builder.Property(a => a.Balance)
              .IsRequired()
              .HasColumnType("DECIMAL(18, 2)");
       
       builder.Property(a => a.Description)
              .IsRequired()
              .HasColumnType("VARCHAR(255)");
    }
}
