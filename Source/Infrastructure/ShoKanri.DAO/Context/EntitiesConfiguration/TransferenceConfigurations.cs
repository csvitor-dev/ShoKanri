using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.DAO.Context.EntitiesConfiguration;

public class TransferenceConfigurations : IEntityTypeConfiguration<Transference>
{
    public void Configure(EntityTypeBuilder<Transference> builder)
    {
        builder.HasOne(t => t.User)
                ;


    }
}
