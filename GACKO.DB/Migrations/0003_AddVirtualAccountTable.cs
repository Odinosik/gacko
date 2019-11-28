using FluentMigrator;

namespace GACKO.DB.Migrations
{
    [Migration(0003)]
    public class AddVirtualAccountTable : Migration
    {
        private const string TableName = "VirtualAccount";
        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Balance").AsFloat().NotNullable()
                .WithColumn("Limit").AsFloat().NotNullable()
                .WithColumn("NotificationBalance").AsFloat().NotNullable()
                .WithColumn("BankAccountId").AsInt32().NotNullable();

            Create.ForeignKey().FromTable(TableName)
                .ForeignColumn("BankAccountId")
                .ToTable("BankAccount").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);

            //Execute.Sql($"INSERT INTO public.\"VirtualAccount\" (\"Id\", \"Name\", \"Balance\", \"Limit\", \"NotificationBalance\", \"BankAccountId\") VALUES(1, 'Konto Wirtualne', '500', '300', '200', '1');");
        }

        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}

