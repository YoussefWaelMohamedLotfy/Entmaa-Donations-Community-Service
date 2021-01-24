using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration()
        {
            ToTable("Organizations");

            Property(o => o.ID).HasColumnName("UserID");
            Property(o => o.FawryToken).IsRequired();

            HasMany(o => o.ContributorsFollowed).WithMany(c => c.OrganizationsFollowing)
                .Map(c =>
                        {
                            c.ToTable("OrganizationFollowers");
                            c.MapLeftKey("OrganizationID");
                            c.MapRightKey("ContributorID");
                        });

            HasMany(o => o.CollectedItemDonations).WithMany(d => d.Organizations)
                .Map(c =>
                        {
                            c.ToTable("CollectedItemDonations");
                            c.MapLeftKey("OrganizationID");
                            c.MapRightKey("ItemID");
                        });

            HasMany(o => o.Posts).WithRequired(p => p.Organization).HasForeignKey(p => p.PostedBy);
            HasMany(o => o.AuctionsCreated).WithRequired(a => a.OrganizationCreator).HasForeignKey(a => a.HostedBy);
            HasMany(o => o.OrganizationAlbumPhotos).WithRequired(o => o.Organization).HasForeignKey(o => o.OrganizationID);
            HasMany(o => o.DonatedItems).WithRequired(d => d.Organization).HasForeignKey(d => d.DonatedTo);
            HasMany(o => o.Subscriptions).WithRequired(s => s.Organization).HasForeignKey(s => s.SubscribedTo);
            HasMany(o => o.ReportedCases).WithRequired(r => r.Organization).HasForeignKey(r => r.ReportedTo);
            HasMany(o => o.MoneyDonationsReceived).WithRequired(r => r.Organization).HasForeignKey(r => r.OrganizationID);
        }
    }
}