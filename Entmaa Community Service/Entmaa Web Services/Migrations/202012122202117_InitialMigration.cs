namespace Entmaa_Web_Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Photos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Path = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
            DropForeignKey("dbo.Auctions", "HostedBy", "dbo.Organizations");
            DropIndex("dbo.Organizations", new[] { "UserID" });
            DropIndex("dbo.Contributors", new[] { "UserID" });
            DropIndex("dbo.PostLikes", new[] { "UserID" });
            DropIndex("dbo.PostLikes", new[] { "PostID" });
            DropIndex("dbo.Posts", new[] { "PostedBy" });
            DropIndex("dbo.Auctions", new[] { "HostedBy" });
            DropTable("dbo.Organizations");
            DropTable("dbo.Contributors");
            DropTable("dbo.PostLikes");
            DropTable("dbo.Photos");
            DropTable("dbo.Posts");
            DropTable("dbo.Users");
            DropTable("dbo.Auctions");
        }
    }
}
