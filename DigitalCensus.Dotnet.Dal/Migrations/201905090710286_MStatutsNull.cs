namespace DigitalCensus.Dotnet.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MStatutsNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Citizens", "MaritalStatus", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Citizens", "MaritalStatus", c => c.Int(nullable: false));
        }
    }
}
