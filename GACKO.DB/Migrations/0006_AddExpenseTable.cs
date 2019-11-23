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
                .WithColumn("").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}

