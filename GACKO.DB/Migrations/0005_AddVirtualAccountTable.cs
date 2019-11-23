using FluentMigrator;

namespace GACKO.DB.Migrations
{
    [Migration(0005)]
    class AddVirtualAccountTable : Migration
    {
        private const string TableName = "VirtualAccount";
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

