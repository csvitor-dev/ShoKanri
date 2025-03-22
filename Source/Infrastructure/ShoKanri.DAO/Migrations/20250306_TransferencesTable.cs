using System;
using System.Data;
using FluentMigrator;

namespace ShoKanri.DAO.Migrations;

[Migration(202503061550)]
public class TransferencesTable : Migration
{
    public override void Up()
    {
        Create.Table("Transferences")
              .WithColumn("Id").AsInt32().PrimaryKey()
              .WithColumn("DestinationId").AsInt32().NotNullable();

        Create.ForeignKey("FK_Transferences_Transaction")
              .FromTable("Transferences").ForeignColumn("Id")
              .ToTable("Transactions").PrimaryColumn("Id")
              .OnDelete(Rule.Cascade);

        Create.ForeignKey("FK_Transferences_Accounts_Destination")
              .FromTable("Transferences").ForeignColumn("DestinationId")
              .ToTable("Accounts").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.Table("Transferences");
    }
}
