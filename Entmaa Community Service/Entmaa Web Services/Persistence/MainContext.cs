using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;
using Entmaa_Web_Services.Persistence.Initializers;
using Entmaa_Web_Services.Persistence.EntityConfigurations;

namespace Entmaa_Web_Services.Persistence
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPhoneNumber> UserPhoneNumbers { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostType> PostTypes { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        
        public DbSet<Event> Events { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionBidder> AuctionBidders { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Badge> Badges { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }

        public DbSet<DonationRequest> DonationRequests { get; set; }
        public DbSet<MoneyDonation> MoneyDonations { get; set; }

        public DbSet<AuctionItemPhoto> AuctionItemPhotos { get; set; }
        public DbSet<PostPhoto> PostPhotos { get; set; }
        public DbSet<DonatedItemPhoto> DonatedItemPhotos { get; set; }
        public DbSet<OrganizationAlbumPhoto> OrganizationAlbumPhotos { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<ReportedItemPhoto> ReportedItemPhotos { get; set; }

        public DbSet<ReportedItem> ReportedItems { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<MoneyDonationOnRequest> MoneyDonationsOnRequest { get; set; }

        public MainContext() : base("name=EntmaaConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new MainInitializerIfModelChanges());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserPhoneNumberConfiguration());
            modelBuilder.Configurations.Add(new UserTypeConfiguration());
            modelBuilder.Configurations.Add(new UserPhotoConfiguration());

            modelBuilder.Configurations.Add(new OrganizationConfiguration());
            modelBuilder.Configurations.Add(new OrganizationsAlbumPhotoConfiguration());
            modelBuilder.Configurations.Add(new ContributorConfiguration());
            
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new PostTypeConfiguration());
            modelBuilder.Configurations.Add(new PostCommentConfiguration());
            modelBuilder.Configurations.Add(new PostPhotoConfiguration());

            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new VolunteerConfiguration());

            modelBuilder.Configurations.Add(new AuctionConfiguration());
            modelBuilder.Configurations.Add(new AuctionBidderConfiguration());
            modelBuilder.Configurations.Add(new AuctionItemPhotoConfiguration());

            modelBuilder.Configurations.Add(new TagConfiguration());
            
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new UserLocationConfiguration());

            modelBuilder.Configurations.Add(new NotificationTypeConfiguration());

            modelBuilder.Configurations.Add(new BadgeConfiguration());
            
            modelBuilder.Configurations.Add(new DonationRequestConfiguration());
            modelBuilder.Configurations.Add(new DonationTypeConfiguration());
            
            modelBuilder.Configurations.Add(new MoneyDonationOnRequestConfiguration());
            
            modelBuilder.Configurations.Add(new DonatedItemConfiguration());
            modelBuilder.Configurations.Add(new DonatedItemPhotoConfiguration());

            modelBuilder.Configurations.Add(new ReportedItemConfiguration());
            modelBuilder.Configurations.Add(new MoneyDonationConfiguration());

            modelBuilder.Configurations.Add(new ReportedItemsPhotoConfiguration());
            modelBuilder.Configurations.Add(new ReportedCaseConfiguration());
        }
    }
}