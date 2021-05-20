namespace Entmaa_Web_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeploymentConfig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "Rating", c => c.Single(nullable: false));
            AlterColumn("dbo.Reviews", "Rating", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Rating", c => c.Double(nullable: false, storeType: "real"));
            AlterColumn("dbo.Organizations", "Rating", c => c.Double(nullable: false, storeType: "real"));
        }
    }
}
