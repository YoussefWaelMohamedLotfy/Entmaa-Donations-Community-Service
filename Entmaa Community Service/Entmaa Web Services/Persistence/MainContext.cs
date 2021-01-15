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
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Post> Posts { get; set; }
        
        public DbSet<Photo> Photo { get; set; }

        public DbSet<Auction> Auctions { get; set; }

        public MainContext() : base("name=EntmaaConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new OrganizationConfiguration());
            modelBuilder.Configurations.Add(new ContributorConfiguration());
            
            modelBuilder.Configurations.Add(new PostConfiguration());

            modelBuilder.Configurations.Add(new PhotoConfiguration());

            modelBuilder.Configurations.Add(new AuctionConfiguration());
        }
    }
}