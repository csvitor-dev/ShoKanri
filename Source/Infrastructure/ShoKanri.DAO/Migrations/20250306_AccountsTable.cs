using System;
using System.Data;
using FluentMigrator;

namespace ShoKanri.DAO.Migrations;

[Migration(202503061509)]
public class AccountsTable : Migration
{
    public override void Up()
    {
        Create.Table("Accounts")
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("Active").AsByte().NotNullable()
              .WithColumn("CreatedOn").AsDateTimeOffset().NotNullable()
              .WithColumn("UpdatedOn").AsDateTimeOffset().NotNullable()
              .WithColumn("UserId").AsInt32().NotNullable()
              .WithColumn("Name").AsString(255).NotNullable()
              .WithColumn("Balance").AsDecimal(18, 2).NotNullable()
              .WithColumn("Description").AsString(255).NotNullable();

        Create.ForeignKey("FK_Accounts_Users")
              .FromTable("Accounts").ForeignColumn("UserId")
              .ToTable("Users").PrimaryColumn("Id")
              .OnDelete(Rule.Cascade);
    }

    public override void Down()
    {
        Delete.Table("Accounts");
    }
}
