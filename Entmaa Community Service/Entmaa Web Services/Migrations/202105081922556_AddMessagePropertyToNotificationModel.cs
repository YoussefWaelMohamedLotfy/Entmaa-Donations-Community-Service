namespace Entmaa_Web_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMessagePropertyToNotificationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "Message");
        }
    }
}
