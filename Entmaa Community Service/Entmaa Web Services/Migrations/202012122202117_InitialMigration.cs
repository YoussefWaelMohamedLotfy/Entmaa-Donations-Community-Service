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
                "dbo.AuctionItemPhotoes",
                c => new
                    {
                        AuctionID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuctionID, t.PhotoURL })
                .ForeignKey("dbo.Auctions", t => t.AuctionID, cascadeDelete: true)
                .Index(t => t.AuctionID);
            
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
                        UserTypeID = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeID, cascadeDelete: true)
                .Index(t => t.UserTypeID);
            
            CreateTable(
                "dbo.CollectedItemDonations",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemID, t.OrganizationId })
                .ForeignKey("dbo.DonatedItems", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .Index(t => t.ItemID)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.DonatedItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        IsDelivered = c.Boolean(nullable: false),
                        DonatedBy = c.Int(nullable: false),
                        DonatedTo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contributors", t => t.DonatedBy)
                .ForeignKey("dbo.Organizations", t => t.DonatedTo)
                .Index(t => t.DonatedBy)
                .Index(t => t.DonatedTo);
            
            CreateTable(
                "dbo.Badges",
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
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .ForeignKey("dbo.Contributors", t => t.ContributorID)
                .Index(t => t.ContributorID)
                .Index(t => t.EventID);
            
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
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TimePosted = c.DateTime(nullable: false),
                        Description = c.String(),
                        PostedBy = c.Int(nullable: false),
                        PostTypeID = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostTypes", t => t.PostTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.PostedBy)
                .Index(t => t.PostedBy)
                .Index(t => t.PostTypeID);
            
            CreateTable(
                "dbo.DonationRequests",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        MoneyNeededAmount = c.Int(nullable: false),
                        MoneyReceivedAmount = c.Int(nullable: false),
                        ItemesNeededCount = c.Int(nullable: false),
                        ItemsReceivedCount = c.Int(nullable: false),
                        DonationTypeID = c.Int(nullable: false),
                        IsFulfilled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.DonationTypes", t => t.DonationTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostID)
                .Index(t => t.PostID)
                .Index(t => t.DonationTypeID);
            
            CreateTable(
                "dbo.DonationTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ItemsDonationsOnRequests",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemID, t.RequestId })
                .ForeignKey("dbo.DonationRequests", t => t.RequestId, cascadeDelete: true)
                .ForeignKey("dbo.DonatedItems", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.MoneyDonationsOnRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContributorId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                        MoneyAmount = c.Int(nullable: false),
                        DonationToken = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DonationRequests", t => t.RequestId, cascadeDelete: true)
                .ForeignKey("dbo.Contributors", t => t.ContributorId)
                .Index(t => t.ContributorId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.PostPhotoes",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostID, t.PhotoURL })
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.PostTypes",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                "dbo.UserPhoneNumbers",
                c => new
                    {
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneNumber)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserPhotos",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.PhotoURL })
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubscribedBy = c.Int(nullable: false),
                        SubscribedTo = c.Int(nullable: false),
                        DaysInterval = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RenewalDate = c.DateTime(nullable: false),
                        CashAmount = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contributors", t => t.SubscribedBy)
                .ForeignKey("dbo.Organizations", t => t.SubscribedTo)
                .Index(t => t.SubscribedBy)
                .Index(t => t.SubscribedTo);
            
            CreateTable(
                "dbo.DonatedItemPhotoes",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemID, t.PhotoURL })
                .ForeignKey("dbo.DonatedItems", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.DonatedItemTags",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemID, t.TagID })
                .ForeignKey("dbo.DonatedItems", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.OrganizationAlbumPhotoes",
                c => new
                    {
                        OrganizationID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrganizationID, t.PhotoURL })
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .Index(t => t.OrganizationID);
            
            CreateTable(
                "dbo.ReportedItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MapLocation = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        ResolvedBy = c.Int(nullable: false),
                        IsFound = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReportedItemPhotoes",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemID, t.PhotoURL })
                .ForeignKey("dbo.ReportedItems", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.MoneyDonations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContributorId = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                        MoneyaAmount = c.Int(nullable: false),
                        DonationToken = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotificationTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DeliveredTo = c.Int(nullable: false),
                        IsSeen = c.Boolean(nullable: false),
                        TypeID = c.Int(nullable: false),
                        TriggerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NotificationTypes", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.ContributorBadges",
                c => new
                    {
                        BadgeID = c.Int(nullable: false),
                        ContributorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BadgeID, t.ContributorID })
                .ForeignKey("dbo.Contributors", t => t.BadgeID, cascadeDelete: true)
                .ForeignKey("dbo.Badges", t => t.ContributorID, cascadeDelete: true)
                .Index(t => t.BadgeID)
                .Index(t => t.ContributorID);
            
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
            DropForeignKey("dbo.Notifications", "TypeID", "dbo.NotificationTypes");
            DropForeignKey("dbo.ReportedItemPhotoes", "ItemID", "dbo.ReportedItems");
            DropForeignKey("dbo.Subscriptions", "SubscribedTo", "dbo.Organizations");
            DropForeignKey("dbo.Posts", "PostedBy", "dbo.Organizations");
            DropForeignKey("dbo.OrganizationAlbumPhotoes", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.DonatedItems", "DonatedTo", "dbo.Organizations");
            DropForeignKey("dbo.CollectedItemDonations", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.ItemsDonationsOnRequests", "ItemID", "dbo.DonatedItems");
            DropForeignKey("dbo.DonatedItemTags", "ItemID", "dbo.DonatedItems");
            DropForeignKey("dbo.DonatedItemPhotoes", "ItemID", "dbo.DonatedItems");
            DropForeignKey("dbo.Subscriptions", "SubscribedBy", "dbo.Contributors");
            DropForeignKey("dbo.MoneyDonationsOnRequests", "ContributorId", "dbo.Contributors");
            DropForeignKey("dbo.Volunteers", "ContributorID", "dbo.Contributors");
            DropForeignKey("dbo.Volunteers", "EventID", "dbo.Events");
            DropForeignKey("dbo.Events", "PostID", "dbo.Posts");
            DropForeignKey("dbo.PostLikes", "UserID", "dbo.Users");
            DropForeignKey("dbo.PostLikes", "PostID", "dbo.Posts");
            DropForeignKey("dbo.UserTags", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.Users", "UserTypeID", "dbo.UserTypes");
            DropForeignKey("dbo.UserPhotos", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserPhoneNumbers", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserLocations", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserLocations", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.PostTags", "PostID", "dbo.Posts");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.EventTags", "EventID", "dbo.Events");
            DropForeignKey("dbo.EventTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.AuctionTags", "AuctionID", "dbo.Auctions");
            DropForeignKey("dbo.AuctionTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.Posts", "PostTypeID", "dbo.PostTypes");
            DropForeignKey("dbo.PostPhotoes", "PostID", "dbo.Posts");
            DropForeignKey("dbo.DonationRequests", "PostID", "dbo.Posts");
            DropForeignKey("dbo.MoneyDonationsOnRequests", "RequestId", "dbo.DonationRequests");
            DropForeignKey("dbo.ItemsDonationsOnRequests", "RequestId", "dbo.DonationRequests");
            DropForeignKey("dbo.DonationRequests", "DonationTypeID", "dbo.DonationTypes");
            DropForeignKey("dbo.DonatedItems", "DonatedBy", "dbo.Contributors");
            DropForeignKey("dbo.ContributorBadges", "ContributorID", "dbo.Badges");
            DropForeignKey("dbo.ContributorBadges", "BadgeID", "dbo.Contributors");
            DropForeignKey("dbo.AuctionBidders", "BidBy", "dbo.Contributors");
            DropForeignKey("dbo.CollectedItemDonations", "ItemID", "dbo.DonatedItems");
            DropForeignKey("dbo.Auctions", "HostedBy", "dbo.Organizations");
            DropForeignKey("dbo.AuctionBidders", "AuctionID", "dbo.Auctions");
            DropForeignKey("dbo.AuctionItemPhotoes", "AuctionID", "dbo.Auctions");
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
            DropIndex("dbo.ContributorBadges", new[] { "ContributorID" });
            DropIndex("dbo.ContributorBadges", new[] { "BadgeID" });
            DropIndex("dbo.Notifications", new[] { "TypeID" });
            DropIndex("dbo.ReportedItemPhotoes", new[] { "ItemID" });
            DropIndex("dbo.OrganizationAlbumPhotoes", new[] { "OrganizationID" });
            DropIndex("dbo.DonatedItemTags", new[] { "ItemID" });
            DropIndex("dbo.DonatedItemPhotoes", new[] { "ItemID" });
            DropIndex("dbo.Subscriptions", new[] { "SubscribedTo" });
            DropIndex("dbo.Subscriptions", new[] { "SubscribedBy" });
            DropIndex("dbo.UserPhotos", new[] { "UserID" });
            DropIndex("dbo.UserPhoneNumbers", new[] { "UserID" });
            DropIndex("dbo.Cities", new[] { "CountryID" });
            DropIndex("dbo.UserLocations", new[] { "CityID" });
            DropIndex("dbo.UserLocations", new[] { "UserID" });
            DropIndex("dbo.PostPhotoes", new[] { "PostID" });
            DropIndex("dbo.MoneyDonationsOnRequests", new[] { "RequestId" });
            DropIndex("dbo.MoneyDonationsOnRequests", new[] { "ContributorId" });
            DropIndex("dbo.ItemsDonationsOnRequests", new[] { "RequestId" });
            DropIndex("dbo.ItemsDonationsOnRequests", new[] { "ItemID" });
            DropIndex("dbo.DonationRequests", new[] { "DonationTypeID" });
            DropIndex("dbo.DonationRequests", new[] { "PostID" });
            DropIndex("dbo.Posts", new[] { "PostTypeID" });
            DropIndex("dbo.Posts", new[] { "PostedBy" });
            DropIndex("dbo.Events", new[] { "PostID" });
            DropIndex("dbo.Volunteers", new[] { "EventID" });
            DropIndex("dbo.Volunteers", new[] { "ContributorID" });
            DropIndex("dbo.DonatedItems", new[] { "DonatedTo" });
            DropIndex("dbo.DonatedItems", new[] { "DonatedBy" });
            DropIndex("dbo.CollectedItemDonations", new[] { "OrganizationId" });
            DropIndex("dbo.CollectedItemDonations", new[] { "ItemID" });
            DropIndex("dbo.Users", new[] { "UserTypeID" });
            DropIndex("dbo.AuctionItemPhotoes", new[] { "AuctionID" });
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
            DropTable("dbo.ContributorBadges");
            DropTable("dbo.Notifications");
            DropTable("dbo.NotificationTypes");
            DropTable("dbo.MoneyDonations");
            DropTable("dbo.ReportedItemPhotoes");
            DropTable("dbo.ReportedItems");
            DropTable("dbo.OrganizationAlbumPhotoes");
            DropTable("dbo.DonatedItemTags");
            DropTable("dbo.DonatedItemPhotoes");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserPhotos");
            DropTable("dbo.UserPhoneNumbers");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.UserLocations");
            DropTable("dbo.Tags");
            DropTable("dbo.PostTypes");
            DropTable("dbo.PostPhotoes");
            DropTable("dbo.MoneyDonationsOnRequests");
            DropTable("dbo.ItemsDonationsOnRequests");
            DropTable("dbo.DonationTypes");
            DropTable("dbo.DonationRequests");
            DropTable("dbo.Posts");
            DropTable("dbo.Events");
            DropTable("dbo.Volunteers");
            DropTable("dbo.Badges");
            DropTable("dbo.DonatedItems");
            DropTable("dbo.CollectedItemDonations");
            DropTable("dbo.Users");
            DropTable("dbo.AuctionItemPhotoes");
            DropTable("dbo.Auctions");
            DropTable("dbo.AuctionBidders");
        }
    }
}
