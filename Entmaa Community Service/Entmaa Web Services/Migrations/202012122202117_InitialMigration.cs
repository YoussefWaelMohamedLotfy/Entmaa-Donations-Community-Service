namespace Entmaa_Web_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuctionBidders",
                c => new
                    {
                        AuctionID = c.Int(nullable: false),
                        BidBy = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        FawryToken = c.String(),
                        ValidUntil = c.DateTime(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuctionID, t.BidBy })
                .ForeignKey("dbo.Auctions", t => t.AuctionID, cascadeDelete: true)
                .ForeignKey("dbo.Contributors", t => t.BidBy)
                .Index(t => t.AuctionID)
                .Index(t => t.BidBy);
            
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HostedBy = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        StartPrice = c.Int(nullable: false),
                        SoldPrice = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.HostedBy)
                .Index(t => t.HostedBy);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        DateJoined = c.DateTime(nullable: false),
                        ProfilePhotoID = c.Int(nullable: false),
                        CoverPhotoID = c.Int(nullable: false),
                        FirebaseToken = c.String(nullable: false),
                        UserType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserLocations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        Address = c.String(),
                        MapLocation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TimePosted = c.DateTime(nullable: false),
                        Description = c.String(),
                        PostedBy = c.Int(nullable: false),
                        PostType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.PostedBy)
                .Index(t => t.PostedBy);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        MapLocation = c.String(nullable: false),
                        Address = c.String(),
                        CityID = c.Int(nullable: false),
                        InterestedCount = c.Int(nullable: false),
                        NeededCount = c.Int(nullable: false),
                        AcceptedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Posts", t => t.PostID)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        ContributorID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ContributorID, t.EventID })
                .ForeignKey("dbo.Contributors", t => t.ContributorID)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .Index(t => t.ContributorID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AuctionTags",
                c => new
                    {
                        TagID = c.Int(nullable: false),
                        AuctionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagID, t.AuctionID })
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .ForeignKey("dbo.Auctions", t => t.AuctionID, cascadeDelete: true)
                .Index(t => t.TagID)
                .Index(t => t.AuctionID);
            
            CreateTable(
                "dbo.EventTags",
                c => new
                    {
                        TagID = c.Int(nullable: false),
                        EventID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagID, t.EventID })
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .Index(t => t.TagID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.PostTags",
                c => new
                    {
                        TagID = c.Int(nullable: false),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagID, t.PostID })
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.TagID)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.UserTags",
                c => new
                    {
                        TagID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagID, t.UserID })
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.TagID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.PostLikes",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostID, t.UserID })
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Contributors",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        Rating = c.Single(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        FoundedDate = c.DateTime(nullable: false),
                        FawryToken = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "UserID", "dbo.Users");
            DropForeignKey("dbo.Contributors", "UserID", "dbo.Users");
            DropForeignKey("dbo.Posts", "PostedBy", "dbo.Organizations");
            DropForeignKey("dbo.PostLikes", "UserID", "dbo.Users");
            DropForeignKey("dbo.PostLikes", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Volunteers", "EventID", "dbo.Events");
            DropForeignKey("dbo.Volunteers", "ContributorID", "dbo.Contributors");
            DropForeignKey("dbo.AuctionBidders", "BidBy", "dbo.Contributors");
            DropForeignKey("dbo.UserTags", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "PostID", "dbo.Posts");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.EventTags", "EventID", "dbo.Events");
            DropForeignKey("dbo.EventTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.AuctionTags", "AuctionID", "dbo.Auctions");
            DropForeignKey("dbo.AuctionTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.Events", "PostID", "dbo.Posts");
            DropForeignKey("dbo.UserLocations", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserLocations", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Auctions", "HostedBy", "dbo.Organizations");
            DropForeignKey("dbo.AuctionBidders", "AuctionID", "dbo.Auctions");
            DropIndex("dbo.Organizations", new[] { "UserID" });
            DropIndex("dbo.Contributors", new[] { "UserID" });
            DropIndex("dbo.PostLikes", new[] { "UserID" });
            DropIndex("dbo.PostLikes", new[] { "PostID" });
            DropIndex("dbo.UserTags", new[] { "UserID" });
            DropIndex("dbo.UserTags", new[] { "TagID" });
            DropIndex("dbo.PostTags", new[] { "PostID" });
            DropIndex("dbo.PostTags", new[] { "TagID" });
            DropIndex("dbo.EventTags", new[] { "EventID" });
            DropIndex("dbo.EventTags", new[] { "TagID" });
            DropIndex("dbo.AuctionTags", new[] { "AuctionID" });
            DropIndex("dbo.AuctionTags", new[] { "TagID" });
            DropIndex("dbo.Volunteers", new[] { "EventID" });
            DropIndex("dbo.Volunteers", new[] { "ContributorID" });
            DropIndex("dbo.Events", new[] { "PostID" });
            DropIndex("dbo.Posts", new[] { "PostedBy" });
            DropIndex("dbo.Cities", new[] { "CountryID" });
            DropIndex("dbo.UserLocations", new[] { "CityID" });
            DropIndex("dbo.UserLocations", new[] { "UserID" });
            DropIndex("dbo.Auctions", new[] { "HostedBy" });
            DropIndex("dbo.AuctionBidders", new[] { "BidBy" });
            DropIndex("dbo.AuctionBidders", new[] { "AuctionID" });
            DropTable("dbo.Organizations");
            DropTable("dbo.Contributors");
            DropTable("dbo.PostLikes");
            DropTable("dbo.UserTags");
            DropTable("dbo.PostTags");
            DropTable("dbo.EventTags");
            DropTable("dbo.AuctionTags");
            DropTable("dbo.Photos");
            DropTable("dbo.Volunteers");
            DropTable("dbo.Tags");
            DropTable("dbo.Events");
            DropTable("dbo.Posts");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.UserLocations");
            DropTable("dbo.Users");
            DropTable("dbo.Auctions");
            DropTable("dbo.AuctionBidders");
        }
    }
}
