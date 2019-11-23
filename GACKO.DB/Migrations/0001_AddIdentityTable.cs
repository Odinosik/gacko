using FluentMigrator;

namespace GACKO.DB.Migrations
{
    [Migration(0001)]
    public class AddIdentityTable : Migration
    {
        public override void Down()
        {
            Delete.Table("AspNetRoles");
            Delete.Table("AspNetUserTokens");
            Delete.Table("AspNetRoleClaims");
            Delete.Table("AspNetUserClaims");
            Delete.Table("AspNetUserLogins");
            Delete.Table("AspNetUserRoles");
            Delete.Table("AspNetUsers");
        }

        public override void Up()
        {
            Create.Table("AspNetRoles")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_AspNetRoles").Identity()
                .WithColumn("ConcurrencyStamp").AsString().Nullable()
                .WithColumn("Name").AsString(256).NotNullable()
                .WithColumn("NormalizedName").AsString(256).Nullable()
                .Indexed("RoleNameIndex");

            Create.Table("AspNetUserTokens")
                .WithColumn("UserId").AsInt32().PrimaryKey("PK_AspNetUserTokens").NotNullable()
                .WithColumn("LoginProvider").AsString(450).NotNullable()
                .WithColumn("Name").AsString(450).NotNullable()
                .WithColumn("Value").AsString().Nullable();

            Create.Table("AspNetUsers")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey("PK_AspNetUsers")
                .WithColumn("AccessFailedCount").AsInt32().NotNullable()
                .WithColumn("ConcurrencyStamp").AsString().Nullable()
                .WithColumn("Email").AsString(256).Nullable()
                .WithColumn("EmailConfirmed").AsBoolean().NotNullable()
                .WithColumn("LockoutEnabled").AsBoolean().NotNullable()
                .WithColumn("LockoutEnd").AsCustom("timestamp with time zone").Nullable()
                .WithColumn("NormalizedEmail").AsString(256).Nullable()
                .WithColumn("NormalizedUserName").AsString(265).Nullable()
                .WithColumn("PasswordHash").AsString().Nullable()
                .WithColumn("PhoneNumber").AsString().Nullable()
                .WithColumn("PhoneNumberConfirmed").AsBoolean().NotNullable()
                .WithColumn("SecurityStamp").AsString().Nullable()
                .WithColumn("TwoFactorEnabled").AsBoolean().NotNullable()
                .WithColumn("UserName").AsString(256).Nullable()
                .WithColumn("FirstName").AsString(256).Nullable()
                .WithColumn("LastName").AsString(256).Nullable();

            Create.Table("AspNetRoleClaims")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_AspNetRoleClaims").Identity()
                .WithColumn("ClaimType").AsString().Nullable()
                .WithColumn("ClaimValue").AsString().Nullable()
                .WithColumn("RoleId").AsInt32().NotNullable().Indexed("IX_AspNetRoleClaims_RoleId")
                .ForeignKey("FK_AspNetRoleClaims_AspNetRoles_RoleId", "AspNetRoles", "Id");

            Create.Table("AspNetUserClaims")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_AspNetUserClaims").Identity()
                .WithColumn("ClaimType").AsString().Nullable()
                .WithColumn("ClaimValue").AsString().Nullable()
                .WithColumn("UserId").AsInt32().NotNullable().Indexed("IX_AspNetUserClaims_UserId")
                .ForeignKey("FK_AspNetUserClaims_AspNetUsers_UserId", "AspNetUsers", "Id")
                .OnDelete(System.Data.Rule.Cascade);

            Create.Table("AspNetUserLogins")
                .WithColumn("LoginProvider").AsInt32().NotNullable().PrimaryKey("PK_AspNetUserLogins")
                .WithColumn("ProviderKey").AsString(450).NotNullable().PrimaryKey("PK_AspNetUserLogins")
                .WithColumn("ProviderDisplayName").AsString().Nullable()
                .WithColumn("UserId").AsInt32()
                .NotNullable()
                .Indexed("IX_AspNetUserLogins_UserId")
                .ForeignKey("FK_AspNetUserLogins_AspNetUsers_UserId", "AspNetUsers", "Id")
                .OnDelete(System.Data.Rule.Cascade);

            Create.Table("AspNetUserRoles")
                .WithColumn("UserId").AsInt32().PrimaryKey("PK_AspNetUserRoles").Indexed("IX_AspNetUserRoles_UserId").ForeignKey("FK_AspNetUserRoles_AspNetUsers_UserId", "AspNetUsers", "Id")
                .WithColumn("RoleId").AsInt32().PrimaryKey("PK_AspNetUserRoles").Indexed("IX_AspNetUserRoles_RoleId").ForeignKey("FK_AspNetUserRoles_AspNetRoles_RoleId", "AspNetRoles", "Id").OnDelete(System.Data.Rule.Cascade);

            Execute.Sql($"INSERT INTO public.\"AspNetRoles\" (\"Id\", \"ConcurrencyStamp\", \"Name\", \"NormalizedName\") VALUES(1, '27c7b0f9-ff4f-4f93-8d77-2984fb970285', 'Administrator', 'ADMINISTRATOR');");

        }
    }
}
