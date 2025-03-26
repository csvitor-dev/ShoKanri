using FluentMigrator;

namespace ShoKanri.DAO.Migrations;

[Migration(202503261002)]
public class MovementKindTable : Migration
{
    public override void Up()
    {
        Create.Table("MovementKind")
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("Kind").AsString(50).NotNullable();

        Create.ForeignKey("FK_Transaction_MovementKind")
              .FromTable("Transactions").ForeignColumn("MovementKind")
              .ToTable("MovementKind").PrimaryColumn("Id");

        Insert.IntoTable("MovementKind")
            .Row(new { Kind = "Expense" })
            .Row(new { Kind = "Income" })
            .Row(new { Kind = "Transference" });
    }

    public override void Down()
    {
        Delete.Table("MovementKind");
    }
}
