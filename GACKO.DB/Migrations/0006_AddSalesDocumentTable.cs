using FluentMigrator;

namespace GACKO.DB.Migrations
{
    [Migration(0006)]
    public class AddSalesDocumentTable : Migration
    {
        private const string TableName = "SalesDocument";
        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("File").AsBinary().NotNullable()
                .WithColumn("ExpenseId").AsInt32().NotNullable();

            Create.ForeignKey().FromTable(TableName)
                .ForeignColumn("ExpenseId")
                .ToTable("Expense").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}

