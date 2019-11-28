﻿using FluentMigrator;

namespace GACKO.DB.Migrations
{
    [Migration(0007)]
    public class AddSubscriptionTable : Migration
    {
        private const string TableName = "Subscription";
        public override void Up()
        {
            Create.Table(TableName)
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Amount").AsFloat().NotNullable()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("VirtualAccountId").AsInt32().NotNullable();

            Create.ForeignKey().FromTable(TableName)
                .ForeignColumn("VirtualAccountId")
                .ToTable("VirtualAccount").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);

        }
        public override void Down()
        {
            Delete.Table(TableName);
        }
    }
}
