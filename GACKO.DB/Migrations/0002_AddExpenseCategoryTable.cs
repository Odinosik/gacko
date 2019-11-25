using FluentMigrator;

namespace GACKO.DB.Migrations
{
    [Migration(0002)]
    class AddExpenseCategoryTable : Migration
    {
        private const string TableName = "ExpenseCategory";
        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}

