using FluentMigrator;

namespace GACKO.DB.Migrations
{
    [Migration(0002)]
    class AddSalesDocumentTable : Migration
    {
        private const string TableName = "SalesDocument";
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

