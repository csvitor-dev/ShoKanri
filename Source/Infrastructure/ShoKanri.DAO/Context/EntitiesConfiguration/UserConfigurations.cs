using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoKanri.Domain.Entities;

namespace ShoKanri.DAO.Context;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Active)
               .IsRequired()
               .HasColumnType("TINYINT");

        builder.Property(u => u.CreatedOn)
               .IsRequired()
               .HasColumnType("DATETIME");

        builder.Property(u => u.UpdatedOn)
               .IsRequired()
               .HasColumnType("DATETIME");

        builder.Property(u => u.Name)
               .IsRequired()
               .HasColumnType("VARCHAR(255)");

        builder.Property(u => u.Email)
               .IsRequired()
               .HasColumnType("VARCHAR(255)");

        builder.Property(u => u.Password)
               .IsRequired()
               .HasColumnType("VARCHAR(255)");
    }
}
