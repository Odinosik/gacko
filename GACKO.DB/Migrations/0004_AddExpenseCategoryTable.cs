using FluentMigrator;

namespace GACKO.DB.Migrations
{
    [Migration(0004)]
    public class AddExpenseCategoryTable : Migration
    {
        private const string TableName = "ExpenseCategory";
        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable();

            Execute.Sql($"INSERT INTO public.\"ExpenseCategory\" (\"Id\", \"Name\") VALUES(10000, 'Obiad');");

        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}

