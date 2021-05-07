namespace Entmaa_Web_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAllPhotoModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuctionItemPhotoes", "AuctionID", "dbo.Auctions");
            DropForeignKey("dbo.PostPhotoes", "PostID", "dbo.Posts");
            DropForeignKey("dbo.ReportedItemPhotoes", "ItemID", "dbo.ReportedItems");
            DropForeignKey("dbo.DonatedItemPhotoes", "ItemID", "dbo.DonatedItems");
            DropForeignKey("dbo.OrganizationAlbumPhotoes", "OrganizationID", "dbo.Organizations");
            DropIndex("dbo.AuctionItemPhotoes", new[] { "AuctionID" });
            DropIndex("dbo.PostPhotoes", new[] { "PostID" });
            DropIndex("dbo.ReportedItemPhotoes", new[] { "ItemID" });
            DropIndex("dbo.DonatedItemPhotoes", new[] { "ItemID" });
            DropIndex("dbo.OrganizationAlbumPhotoes", new[] { "OrganizationID" });
            AddColumn("dbo.Auctions", "PhotoUrl", c => c.String());
            AddColumn("dbo.DonatedItems", "ItemPhotoUrl", c => c.String());
            AddColumn("dbo.Posts", "PostPhotoUrl", c => c.String());
            AddColumn("dbo.ReportedItems", "ItemPhotoUrl", c => c.String());
            DropTable("dbo.AuctionItemPhotoes");
            DropTable("dbo.PostPhotoes");
            DropTable("dbo.ReportedItemPhotoes");
            DropTable("dbo.DonatedItemPhotoes");
            DropTable("dbo.OrganizationAlbumPhotoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrganizationAlbumPhotoes",
                c => new
                    {
                        OrganizationID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => new { t.OrganizationID, t.PhotoURL });
            
            CreateTable(
                "dbo.DonatedItemPhotoes",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => new { t.ItemID, t.PhotoURL });
            
            CreateTable(
                "dbo.ReportedItemPhotoes",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => new { t.ItemID, t.PhotoURL });
            
            CreateTable(
                "dbo.PostPhotoes",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => new { t.PostID, t.PhotoURL });
            
            CreateTable(
                "dbo.AuctionItemPhotoes",
                c => new
                    {
                        AuctionID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => new { t.AuctionID, t.PhotoURL });
            
            DropColumn("dbo.ReportedItems", "ItemPhotoUrl");
            DropColumn("dbo.Posts", "PostPhotoUrl");
            DropColumn("dbo.DonatedItems", "ItemPhotoUrl");
            DropColumn("dbo.Auctions", "PhotoUrl");
            CreateIndex("dbo.OrganizationAlbumPhotoes", "OrganizationID");
            CreateIndex("dbo.DonatedItemPhotoes", "ItemID");
            CreateIndex("dbo.ReportedItemPhotoes", "ItemID");
            CreateIndex("dbo.PostPhotoes", "PostID");
            CreateIndex("dbo.AuctionItemPhotoes", "AuctionID");
            AddForeignKey("dbo.OrganizationAlbumPhotoes", "OrganizationID", "dbo.Organizations", "UserID");
            AddForeignKey("dbo.DonatedItemPhotoes", "ItemID", "dbo.DonatedItems", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ReportedItemPhotoes", "ItemID", "dbo.ReportedItems", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PostPhotoes", "PostID", "dbo.Posts", "ID", cascadeDelete: true);
            AddForeignKey("dbo.AuctionItemPhotoes", "AuctionID", "dbo.Auctions", "ID", cascadeDelete: true);
        }
    }
}
