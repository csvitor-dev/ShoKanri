using System;
using FluentMigrator;

namespace ShoKanri.DAO.Migrations;

[Migration(202503061502)]
public class UsersTable : Migration
{
    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Active").AsByte().NotNullable()
            .WithColumn("CreatedOn").AsDateTimeOffset().NotNullable()
            .WithColumn("UpdatedOn").AsDateTimeOffset().NotNullable()
            .WithColumn("Name").AsString(255).NotNullable()
            .WithColumn("Email").AsString(255).NotNullable().Unique()
            .WithColumn("Password").AsString(255).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Users");
    }
}
