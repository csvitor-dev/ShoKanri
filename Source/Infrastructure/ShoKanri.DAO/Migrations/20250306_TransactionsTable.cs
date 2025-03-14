using System;
using System.Data;
using FluentMigrator;

namespace ShoKanri.DAO.Migrations;

[Migration(202503061535)]
public class TransactionsTable : Migration
{
    public override void Up()
    {
        Create.Table("Transactions")
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("CreatedOn").AsDateTimeOffset().NotNullable()
              .WithColumn("MovementKind").AsInt32().NotNullable()
              .WithColumn("AccountId").AsInt32().NotNullable()
              .WithColumn("Amount").AsDecimal(18, 2).NotNullable();

        Create.ForeignKey("FK_Trasactions_Accounts")
              .FromTable("Transactions").ForeignColumn("AccountId")
              .ToTable("Accounts").PrimaryColumn("Id")
              .OnDelete(Rule.Cascade);
    }

    public override void Down()
    {
        Delete.Table("Transactions");
    }
}
