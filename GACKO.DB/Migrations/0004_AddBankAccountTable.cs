using FluentMigrator;

namespace GACKO.DB.Migrations
{
    [Migration(0004)]
    class AddBankAccountTable : Migration
    {
        private const string TableName = "BankAccount";
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

