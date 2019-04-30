namespace DigitalCensus.Dotnet.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMgrtn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citizens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UniqueKey = c.Guid(nullable: false),
                        PersonName = c.String(),
                        RelationWithHead = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        MarriageAge = c.Int(),
                        OccupationType = c.Int(nullable: false),
                        CensusHouseNumber = c.Int(),
                        IndustryNature = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Houses", t => t.CensusHouseNumber)
                .Index(t => t.CensusHouseNumber);
            
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UniqueKey = c.Guid(nullable: false),
                        ApartmentNumber = c.String(),
                        StreetName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        HouseHeadPerson = c.String(),
                        OwnershipStatus = c.Int(nullable: false),
                        RoomQuantity = c.Int(nullable: false),
                        CensusHouseNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UniqueKey = c.Guid(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UniqueKey = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        ProfilePictureAddress = c.String(nullable: false),
                        AadharNumber = c.String(nullable: false),
                        IsApprover = c.Boolean(nullable: false),
                        RequestStatus = c.Int(nullable: false),
                        UserAccount_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_ID)
                .Index(t => t.UserAccount_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserAccount_ID", "dbo.UserAccounts");
            DropForeignKey("dbo.Citizens", "CensusHouseNumber", "dbo.Houses");
            DropIndex("dbo.Users", new[] { "UserAccount_ID" });
            DropIndex("dbo.Citizens", new[] { "CensusHouseNumber" });
            DropTable("dbo.Users");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Houses");
            DropTable("dbo.Citizens");
        }
    }
}
