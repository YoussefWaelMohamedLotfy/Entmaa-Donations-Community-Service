using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;
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
        
        public DbSet<Photo> Photo { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionBidder> AuctionBidders { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }

        public DbSet<DonationRequest> DonationRequests { get; set; }
        
        

        public MainContext() : base("name=EntmaaConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserPhoneNumberConfiguration());
            modelBuilder.Configurations.Add(new UserTypeConfiguration());

            modelBuilder.Configurations.Add(new OrganizationConfiguration());
            modelBuilder.Configurations.Add(new ContributorConfiguration());
            
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new PostTypeConfiguration());

            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new VolunteerConfiguration());

            modelBuilder.Configurations.Add(new PhotoConfiguration());

            modelBuilder.Configurations.Add(new AuctionConfiguration());
            modelBuilder.Configurations.Add(new AuctionBidderConfiguration());

            modelBuilder.Configurations.Add(new TagConfiguration());
            
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new UserLocationConfiguration());
            modelBuilder.Configurations.Add(new DonationRequestConfiguration());
            modelBuilder.Configurations.Add(new BadgesConfiguration());
            modelBuilder.Configurations.Add(new DonationOnRequestConfiguration());
            modelBuilder.Configurations.Add(new DonatedItemsConfiguration());
            modelBuilder.Configurations.Add(new ReportedItemsConfiguration());
            modelBuilder.Configurations.Add(new PostPhotosConfiguration());
            modelBuilder.Configurations.Add(new DonatedItemPhotosConfiguration());
            modelBuilder.Configurations.Add(new AuctionItemPhotosConfiguration());
            modelBuilder.Configurations.Add(new ReportedItemsPhotosConfiguration());
            modelBuilder.Configurations.Add(new OrganizationsAlbumPhotosConfiguration());


            
        }
    }
}