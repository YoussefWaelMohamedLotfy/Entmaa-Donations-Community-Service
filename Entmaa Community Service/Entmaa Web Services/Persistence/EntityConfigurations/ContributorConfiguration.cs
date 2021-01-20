using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class ContributorConfiguration : EntityTypeConfiguration<Contributor>
    {
        public ContributorConfiguration()
        {
            ToTable("Contributors");

            Property(c => c.ID).HasColumnName("UserID");
            Property(c => c.Gender).IsRequired();


            HasMany(c => c.BadgesOwned).WithMany(b => b.Contributors)
                .Map(m =>
                        {
                            m.ToTable("ContributorBadges");
                            m.MapLeftKey("BadgeID");
                            m.MapRightKey("ContributorID");
                        });

            HasMany(c => c.EventsVolunteeredIn).WithRequired(v => v.Contributor).HasForeignKey(v => v.ContributorID);
            HasMany(c => c.AuctionsJoined).WithRequired(a => a.Contributor).HasForeignKey(a => a.BidBy);
            HasMany(c => c.MoneyDonationsOnRequests).WithRequired(m => m.Contributor).HasForeignKey(m => m.ContributorID);
            HasMany(c => c.DonatedItems).WithRequired(d => d.Contributor).HasForeignKey(d => d.DonatedBy);
            HasMany(c => c.Subscriptions).WithRequired(s => s.Contributor).HasForeignKey(s => s.SubscribedBy);
            HasMany(c => c.ReportedCases).WithRequired(r => r.Contributor).HasForeignKey(r => r.ReportedBy);
            HasMany(c => c.MoneyDonationsMade).WithRequired(r => r.Contributor).HasForeignKey(r => r.ContributorID);
        }
    }
}