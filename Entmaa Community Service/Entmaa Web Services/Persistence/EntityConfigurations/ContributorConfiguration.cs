using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
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

            HasMany(c => c.EventsVolunteeredIn).WithRequired(v => v.Contributor).HasForeignKey(v => v.ContributorID);
            HasMany(c => c.AuctionsJoined).WithRequired(a => a.Contributor).HasForeignKey(a => a.BidBy);
        }
    }
}