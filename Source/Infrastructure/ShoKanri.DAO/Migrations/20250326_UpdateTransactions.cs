using FluentMigrator;

namespace ShoKanri.DAO.Migrations;

[Migration(202503261255)]
public class UpdateTransactions : Migration
{
    public override void Up()
    {
        Alter.Table("Transactions").AddColumn("Description").AsString(255).NotNullable();
    }

    public override void Down()
    {
        Delete.Column("Description").FromTable("Transactions");
    }
}
