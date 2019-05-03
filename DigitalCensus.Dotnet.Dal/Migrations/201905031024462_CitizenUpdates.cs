namespace DigitalCensus.Dotnet.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CitizenUpdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citizens", "CensusHouseNumber", "dbo.Houses");
            DropIndex("dbo.Citizens", new[] { "CensusHouseNumber" });
            DropColumn("dbo.Citizens", "CensusHouseNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Citizens", "CensusHouseNumber", c => c.Int());
            CreateIndex("dbo.Citizens", "CensusHouseNumber");
            AddForeignKey("dbo.Citizens", "CensusHouseNumber", "dbo.Houses", "ID");
        }
    }
}
