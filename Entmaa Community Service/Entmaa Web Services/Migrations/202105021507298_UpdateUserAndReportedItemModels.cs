namespace Entmaa_Web_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserAndReportedItemModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserPhotoes", "UserID", "dbo.Users");
            DropIndex("dbo.UserPhotoes", new[] { "UserID" });
            AddColumn("dbo.Users", "ProfilePhotoUrl", c => c.String());
            AddColumn("dbo.Users", "CoverPhotoUrl", c => c.String());
            DropTable("dbo.UserPhotoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserPhotoes",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        PhotoType = c.Byte(nullable: false),
                        PhotoURL = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => new { t.UserID, t.PhotoType });
            
            DropColumn("dbo.Users", "CoverPhotoUrl");
            DropColumn("dbo.Users", "ProfilePhotoUrl");
            CreateIndex("dbo.UserPhotoes", "UserID");
            AddForeignKey("dbo.UserPhotoes", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
