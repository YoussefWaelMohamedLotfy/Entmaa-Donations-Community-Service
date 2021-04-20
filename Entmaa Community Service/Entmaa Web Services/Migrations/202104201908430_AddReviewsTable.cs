namespace Entmaa_Web_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReviewsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ContributorID = c.Int(nullable: false),
                        OrganizationID = c.Int(nullable: false),
                        Rating = c.Single(nullable: false),
                        ReviewComment = c.String(),
                    })
                .PrimaryKey(t => new { t.ContributorID, t.OrganizationID })
                .ForeignKey("dbo.Contributors", t => t.ContributorID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .Index(t => t.ContributorID)
                .Index(t => t.OrganizationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.Reviews", "ContributorID", "dbo.Contributors");
            DropIndex("dbo.Reviews", new[] { "OrganizationID" });
            DropIndex("dbo.Reviews", new[] { "ContributorID" });
            DropTable("dbo.Reviews");
        }
    }
}
