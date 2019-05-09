namespace DigitalCensus.Dotnet.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserAccount_ID", "dbo.UserAccounts");
            DropIndex("dbo.Users", new[] { "UserAccount_ID" });
            AlterColumn("dbo.Citizens", "PersonName", c => c.String(nullable: false));
            AlterColumn("dbo.Houses", "ApartmentNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Houses", "StreetName", c => c.String(nullable: false));
            AlterColumn("dbo.Houses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Houses", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Houses", "HouseHeadPerson", c => c.String(nullable: false));
            AlterColumn("dbo.Houses", "CensusHouseNumber", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserAccount_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "UserAccount_ID");
            AddForeignKey("dbo.Users", "UserAccount_ID", "dbo.UserAccounts", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserAccount_ID", "dbo.UserAccounts");
            DropIndex("dbo.Users", new[] { "UserAccount_ID" });
            AlterColumn("dbo.Users", "UserAccount_ID", c => c.Int());
            AlterColumn("dbo.UserAccounts", "Password", c => c.String());
            AlterColumn("dbo.UserAccounts", "Email", c => c.String());
            AlterColumn("dbo.Houses", "CensusHouseNumber", c => c.String());
            AlterColumn("dbo.Houses", "HouseHeadPerson", c => c.String());
            AlterColumn("dbo.Houses", "State", c => c.String());
            AlterColumn("dbo.Houses", "City", c => c.String());
            AlterColumn("dbo.Houses", "StreetName", c => c.String());
            AlterColumn("dbo.Houses", "ApartmentNumber", c => c.String());
            AlterColumn("dbo.Citizens", "PersonName", c => c.String());
            CreateIndex("dbo.Users", "UserAccount_ID");
            AddForeignKey("dbo.Users", "UserAccount_ID", "dbo.UserAccounts", "ID");
        }
    }
}
