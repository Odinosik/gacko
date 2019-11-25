using FluentMigrator;

namespace GACKO.DB.Migrations
{
    [Migration(0003)]
    class AddBankAccountTable : Migration
    {
        private const string TableName = "BankAccount";
        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Iban").AsString().NotNullable()
                .WithColumn("Balance").AsFloat().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable();

            Create.ForeignKey().FromTable(TableName)
                .ForeignColumn("UserId")
                .ToTable("AspNetUsers").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}

