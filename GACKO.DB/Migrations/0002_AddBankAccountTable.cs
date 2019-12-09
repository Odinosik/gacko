using FluentMigrator;

namespace GACKO.DB.Migrations
{
    [Migration(0002)]
    public class AddBankAccountTable : Migration
    {
        private const string TableName = "BankAccount";
        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Iban").AsString().NotNullable()
                .WithColumn("Balance").AsDouble().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable();

            Create.ForeignKey().FromTable(TableName)
                .ForeignColumn("UserId")
                .ToTable("AspNetUsers").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);

<<<<<<< HEAD
            Execute.Sql($"INSERT INTO public.\"BankAccount\" (\"Id\", \"Iban\", \"Balance\", \"UserId\") VALUES(1, '27 1140 2004 0000 3002 0135 5387 ', '1000', '1');");
=======
            //Execute.Sql($"INSERT INTO public.\"BankAccount\" (\"Id\", \"Iban\", \"Balance\", \"UserId\") VALUES(1, '27 1140 2004 0000 3002 0135 5387 ', '1000', '100');");
>>>>>>> 03e217f3e4f9c8a621aa158e09a0afbca06c92ef
        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}

