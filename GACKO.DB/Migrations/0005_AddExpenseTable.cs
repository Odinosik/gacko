using FluentMigrator;

namespace GACKO.DB.Migrations
{
    [Migration(0006)]
    class AddExpenseTable : Migration
    {
        private const string TableName = "Expense";
        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Amount").AsFloat().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("VirtualAccountId").AsInt32().NotNullable()
                .WithColumn("ExpenseCategoryId").AsInt32().NotNullable();

            Create.ForeignKey().FromTable(TableName)
                .ForeignColumn("VirtualAccountId")
                .ToTable("VirtualAccount").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);

            Create.ForeignKey().FromTable(TableName)
                .ForeignColumn("ExpenseCategoryId")
                .ToTable("ExpenseCategory").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}

