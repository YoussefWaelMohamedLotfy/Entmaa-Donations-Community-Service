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
                        PhotoURL = c.String(nullable: false, maxLength: 450),
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
                        FirebaseToken = c.String(nullable: false),
                        UserTypeID = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeID, cascadeDelete: true)
                .Index(t => t.UserTypeID);
            
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
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostID)
                .Index(t => t.PostID)
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
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CityID);
            
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
                "dbo.PostComments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                        DateCommented = c.DateTime(nullable: false),
                        ParentComment_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostComments", t => t.ParentComment_ID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.UserID)
                .Index(t => t.ParentComment_ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TimePosted = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
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
                        ItemsNeededCount = c.Int(nullable: false),
                        ItemsReceivedCount = c.Int(nullable: false),
                        DonationTypeID = c.Byte(nullable: false),
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
                        ID = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MoneyDonationOnRequests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContributorID = c.Int(nullable: false),
                        RequestID = c.Int(nullable: false),
                        MoneyAmount = c.Int(nullable: false),
                        DonationToken = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DonationRequests", t => t.RequestID, cascadeDelete: true)
                .ForeignKey("dbo.Contributors", t => t.ContributorID)
                .Index(t => t.ContributorID)
                .Index(t => t.RequestID);
            
            CreateTable(
                "dbo.PostPhotoes",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false, maxLength: 450),
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
                "dbo.ReportedItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        MapLocation = c.String(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ResolvedBy = c.Int(nullable: false),
                        IsFound = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contributors", t => t.CreatedBy)
                .ForeignKey("dbo.Contributors", t => t.ResolvedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.ResolvedBy);
            
            CreateTable(
                "dbo.ReportedItemPhotoes",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => new { t.ItemID, t.PhotoURL })
                .ForeignKey("dbo.ReportedItems", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.UserPhotoes",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        PhotoType = c.Byte(nullable: false),
                        PhotoURL = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => new { t.UserID, t.PhotoType })
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
                "dbo.MoneyDonations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContributorID = c.Int(nullable: false),
                        OrganizationID = c.Int(nullable: false),
                        MoneyAmount = c.Int(nullable: false),
                        DonationToken = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contributors", t => t.ContributorID)
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .Index(t => t.ContributorID)
                .Index(t => t.OrganizationID);
            
            CreateTable(
                "dbo.ReportedCases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Photo = c.String(nullable: false),
                        ReportedBy = c.Int(nullable: false),
                        ReportedTo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contributors", t => t.ReportedBy)
                .ForeignKey("dbo.Organizations", t => t.ReportedTo)
                .Index(t => t.ReportedBy)
                .Index(t => t.ReportedTo);
            
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
                        PhotoURL = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => new { t.ItemID, t.PhotoURL })
                .ForeignKey("dbo.DonatedItems", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.OrganizationAlbumPhotoes",
                c => new
                    {
                        OrganizationID = c.Int(nullable: false),
                        PhotoURL = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => new { t.OrganizationID, t.PhotoURL })
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .Index(t => t.OrganizationID);
            
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
                "dbo.NotificationTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.ItemDonationOnRequests",
                c => new
                    {
                        RequestID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RequestID, t.ItemID })
                .ForeignKey("dbo.DonationRequests", t => t.RequestID, cascadeDelete: true)
                .ForeignKey("dbo.DonatedItems", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.RequestID)
                .Index(t => t.ItemID);
            
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
                "dbo.DonatedItemTags",
                c => new
                    {
                        TagID = c.Int(nullable: false),
                        DonatedItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagID, t.DonatedItemID })
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .ForeignKey("dbo.DonatedItems", t => t.DonatedItemID, cascadeDelete: true)
                .Index(t => t.TagID)
                .Index(t => t.DonatedItemID);
            
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
                "dbo.ReportedItemTags",
                c => new
                    {
                        TagID = c.Int(nullable: false),
                        ReportedItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagID, t.ReportedItemID })
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .ForeignKey("dbo.ReportedItems", t => t.ReportedItemID, cascadeDelete: true)
                .Index(t => t.TagID)
                .Index(t => t.ReportedItemID);
            
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
                "dbo.CollectedItemDonations",
                c => new
                    {
                        OrganizationID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrganizationID, t.ItemID })
                .ForeignKey("dbo.Organizations", t => t.OrganizationID, cascadeDelete: true)
                .ForeignKey("dbo.DonatedItems", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.OrganizationID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.OrganizationFollowers",
                c => new
                    {
                        OrganizationID = c.Int(nullable: false),
                        ContributorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrganizationID, t.ContributorID })
                .ForeignKey("dbo.Organizations", t => t.OrganizationID)
                .ForeignKey("dbo.Contributors", t => t.ContributorID)
                .Index(t => t.OrganizationID)
                .Index(t => t.ContributorID);
            
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
            DropForeignKey("dbo.Subscriptions", "SubscribedTo", "dbo.Organizations");
            DropForeignKey("dbo.ReportedCases", "ReportedTo", "dbo.Organizations");
            DropForeignKey("dbo.Posts", "PostedBy", "dbo.Organizations");
            DropForeignKey("dbo.OrganizationAlbumPhotoes", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.MoneyDonations", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.DonatedItems", "DonatedTo", "dbo.Organizations");
            DropForeignKey("dbo.OrganizationFollowers", "ContributorID", "dbo.Contributors");
            DropForeignKey("dbo.OrganizationFollowers", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.CollectedItemDonations", "ItemID", "dbo.DonatedItems");
            DropForeignKey("dbo.CollectedItemDonations", "OrganizationID", "dbo.Organizations");
            DropForeignKey("dbo.DonatedItemPhotoes", "ItemID", "dbo.DonatedItems");
            DropForeignKey("dbo.Subscriptions", "SubscribedBy", "dbo.Contributors");
            DropForeignKey("dbo.ReportedItems", "ResolvedBy", "dbo.Contributors");
            DropForeignKey("dbo.ReportedItems", "CreatedBy", "dbo.Contributors");
            DropForeignKey("dbo.ReportedCases", "ReportedBy", "dbo.Contributors");
            DropForeignKey("dbo.MoneyDonationOnRequests", "ContributorID", "dbo.Contributors");
            DropForeignKey("dbo.MoneyDonations", "ContributorID", "dbo.Contributors");
            DropForeignKey("dbo.Volunteers", "ContributorID", "dbo.Contributors");
            DropForeignKey("dbo.Volunteers", "EventID", "dbo.Events");
            DropForeignKey("dbo.Events", "PostID", "dbo.Posts");
            DropForeignKey("dbo.UserLocations", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Users", "UserTypeID", "dbo.UserTypes");
            DropForeignKey("dbo.UserPhotoes", "UserID", "dbo.Users");
            DropForeignKey("dbo.PostComments", "UserID", "dbo.Users");
            DropForeignKey("dbo.PostLikes", "UserID", "dbo.Users");
            DropForeignKey("dbo.PostLikes", "PostID", "dbo.Posts");
            DropForeignKey("dbo.UserTags", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ReportedItemTags", "ReportedItemID", "dbo.ReportedItems");
            DropForeignKey("dbo.ReportedItemTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ReportedItemPhotoes", "ItemID", "dbo.ReportedItems");
            DropForeignKey("dbo.PostTags", "PostID", "dbo.Posts");
            DropForeignKey("dbo.PostTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.EventTags", "EventID", "dbo.Events");
            DropForeignKey("dbo.EventTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.DonatedItemTags", "DonatedItemID", "dbo.DonatedItems");
            DropForeignKey("dbo.DonatedItemTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.AuctionTags", "AuctionID", "dbo.Auctions");
            DropForeignKey("dbo.AuctionTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.Posts", "PostTypeID", "dbo.PostTypes");
            DropForeignKey("dbo.PostPhotoes", "PostID", "dbo.Posts");
            DropForeignKey("dbo.PostComments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.DonationRequests", "PostID", "dbo.Posts");
            DropForeignKey("dbo.MoneyDonationOnRequests", "RequestID", "dbo.DonationRequests");
            DropForeignKey("dbo.ItemDonationOnRequests", "ItemID", "dbo.DonatedItems");
            DropForeignKey("dbo.ItemDonationOnRequests", "RequestID", "dbo.DonationRequests");
            DropForeignKey("dbo.DonationRequests", "DonationTypeID", "dbo.DonationTypes");
            DropForeignKey("dbo.PostComments", "ParentComment_ID", "dbo.PostComments");
            DropForeignKey("dbo.UserPhoneNumbers", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserLocations", "UserID", "dbo.Users");
            DropForeignKey("dbo.Events", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.DonatedItems", "DonatedBy", "dbo.Contributors");
            DropForeignKey("dbo.ContributorBadges", "ContributorID", "dbo.Badges");
            DropForeignKey("dbo.ContributorBadges", "BadgeID", "dbo.Contributors");
            DropForeignKey("dbo.AuctionBidders", "BidBy", "dbo.Contributors");
            DropForeignKey("dbo.Auctions", "HostedBy", "dbo.Organizations");
            DropForeignKey("dbo.AuctionBidders", "AuctionID", "dbo.Auctions");
            DropForeignKey("dbo.AuctionItemPhotoes", "AuctionID", "dbo.Auctions");
            DropIndex("dbo.Organizations", new[] { "UserID" });
            DropIndex("dbo.Contributors", new[] { "UserID" });
            DropIndex("dbo.OrganizationFollowers", new[] { "ContributorID" });
            DropIndex("dbo.OrganizationFollowers", new[] { "OrganizationID" });
            DropIndex("dbo.CollectedItemDonations", new[] { "ItemID" });
            DropIndex("dbo.CollectedItemDonations", new[] { "OrganizationID" });
            DropIndex("dbo.PostLikes", new[] { "UserID" });
            DropIndex("dbo.PostLikes", new[] { "PostID" });
            DropIndex("dbo.UserTags", new[] { "UserID" });
            DropIndex("dbo.UserTags", new[] { "TagID" });
            DropIndex("dbo.ReportedItemTags", new[] { "ReportedItemID" });
            DropIndex("dbo.ReportedItemTags", new[] { "TagID" });
            DropIndex("dbo.PostTags", new[] { "PostID" });
            DropIndex("dbo.PostTags", new[] { "TagID" });
            DropIndex("dbo.EventTags", new[] { "EventID" });
            DropIndex("dbo.EventTags", new[] { "TagID" });
            DropIndex("dbo.DonatedItemTags", new[] { "DonatedItemID" });
            DropIndex("dbo.DonatedItemTags", new[] { "TagID" });
            DropIndex("dbo.AuctionTags", new[] { "AuctionID" });
            DropIndex("dbo.AuctionTags", new[] { "TagID" });
            DropIndex("dbo.ItemDonationOnRequests", new[] { "ItemID" });
            DropIndex("dbo.ItemDonationOnRequests", new[] { "RequestID" });
            DropIndex("dbo.ContributorBadges", new[] { "ContributorID" });
            DropIndex("dbo.ContributorBadges", new[] { "BadgeID" });
            DropIndex("dbo.Notifications", new[] { "TypeID" });
            DropIndex("dbo.OrganizationAlbumPhotoes", new[] { "OrganizationID" });
            DropIndex("dbo.DonatedItemPhotoes", new[] { "ItemID" });
            DropIndex("dbo.Subscriptions", new[] { "SubscribedTo" });
            DropIndex("dbo.Subscriptions", new[] { "SubscribedBy" });
            DropIndex("dbo.ReportedCases", new[] { "ReportedTo" });
            DropIndex("dbo.ReportedCases", new[] { "ReportedBy" });
            DropIndex("dbo.MoneyDonations", new[] { "OrganizationID" });
            DropIndex("dbo.MoneyDonations", new[] { "ContributorID" });
            DropIndex("dbo.UserPhotoes", new[] { "UserID" });
            DropIndex("dbo.ReportedItemPhotoes", new[] { "ItemID" });
            DropIndex("dbo.ReportedItems", new[] { "ResolvedBy" });
            DropIndex("dbo.ReportedItems", new[] { "CreatedBy" });
            DropIndex("dbo.PostPhotoes", new[] { "PostID" });
            DropIndex("dbo.MoneyDonationOnRequests", new[] { "RequestID" });
            DropIndex("dbo.MoneyDonationOnRequests", new[] { "ContributorID" });
            DropIndex("dbo.DonationRequests", new[] { "DonationTypeID" });
            DropIndex("dbo.DonationRequests", new[] { "PostID" });
            DropIndex("dbo.Posts", new[] { "PostTypeID" });
            DropIndex("dbo.Posts", new[] { "PostedBy" });
            DropIndex("dbo.PostComments", new[] { "ParentComment_ID" });
            DropIndex("dbo.PostComments", new[] { "UserID" });
            DropIndex("dbo.PostComments", new[] { "PostID" });
            DropIndex("dbo.UserPhoneNumbers", new[] { "UserID" });
            DropIndex("dbo.UserLocations", new[] { "CityID" });
            DropIndex("dbo.UserLocations", new[] { "UserID" });
            DropIndex("dbo.Cities", new[] { "CountryID" });
            DropIndex("dbo.Events", new[] { "CityID" });
            DropIndex("dbo.Events", new[] { "PostID" });
            DropIndex("dbo.Volunteers", new[] { "EventID" });
            DropIndex("dbo.Volunteers", new[] { "ContributorID" });
            DropIndex("dbo.DonatedItems", new[] { "DonatedTo" });
            DropIndex("dbo.DonatedItems", new[] { "DonatedBy" });
            DropIndex("dbo.Users", new[] { "UserTypeID" });
            DropIndex("dbo.AuctionItemPhotoes", new[] { "AuctionID" });
            DropIndex("dbo.Auctions", new[] { "HostedBy" });
            DropIndex("dbo.AuctionBidders", new[] { "BidBy" });
            DropIndex("dbo.AuctionBidders", new[] { "AuctionID" });
            DropTable("dbo.Organizations");
            DropTable("dbo.Contributors");
            DropTable("dbo.OrganizationFollowers");
            DropTable("dbo.CollectedItemDonations");
            DropTable("dbo.PostLikes");
            DropTable("dbo.UserTags");
            DropTable("dbo.ReportedItemTags");
            DropTable("dbo.PostTags");
            DropTable("dbo.EventTags");
            DropTable("dbo.DonatedItemTags");
            DropTable("dbo.AuctionTags");
            DropTable("dbo.ItemDonationOnRequests");
            DropTable("dbo.ContributorBadges");
            DropTable("dbo.NotificationTypes");
            DropTable("dbo.Notifications");
            DropTable("dbo.OrganizationAlbumPhotoes");
            DropTable("dbo.DonatedItemPhotoes");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.ReportedCases");
            DropTable("dbo.MoneyDonations");
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserPhotoes");
            DropTable("dbo.ReportedItemPhotoes");
            DropTable("dbo.ReportedItems");
            DropTable("dbo.Tags");
            DropTable("dbo.PostTypes");
            DropTable("dbo.PostPhotoes");
            DropTable("dbo.MoneyDonationOnRequests");
            DropTable("dbo.DonationTypes");
            DropTable("dbo.DonationRequests");
            DropTable("dbo.Posts");
            DropTable("dbo.PostComments");
            DropTable("dbo.UserPhoneNumbers");
            DropTable("dbo.UserLocations");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Events");
            DropTable("dbo.Volunteers");
            DropTable("dbo.Badges");
            DropTable("dbo.DonatedItems");
            DropTable("dbo.Users");
            DropTable("dbo.AuctionItemPhotoes");
            DropTable("dbo.Auctions");
            DropTable("dbo.AuctionBidders");
        }
    }
}
