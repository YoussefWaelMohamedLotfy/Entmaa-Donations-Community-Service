namespace Entmaa_Web_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDonationRequestsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonationRequests", "ItemsAccepted", c => c.Boolean(nullable: false));
            DropColumn("dbo.DonationRequests", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DonationRequests", "Title", c => c.String(nullable: false));
            DropColumn("dbo.DonationRequests", "ItemsAccepted");
        }
    }
}
