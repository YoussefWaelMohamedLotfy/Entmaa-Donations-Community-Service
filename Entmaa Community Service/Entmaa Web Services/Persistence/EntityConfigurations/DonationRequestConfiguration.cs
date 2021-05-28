using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class DonationRequestConfiguration : EntityTypeConfiguration<DonationRequest>
    {
        public DonationRequestConfiguration()
        {
            HasKey(d => d.PostID);

            HasRequired(d => d.Post).WithRequiredDependent(p => p.DonationRequest);

            HasMany(d => d.MoneyDonationsOnRequest).WithRequired(m => m.DonationRequest).HasForeignKey(m => m.RequestID);

            HasMany(d => d.Items).WithMany(d => d.Donations)
                .Map(c => 
                        {
                            c.ToTable("ItemDonationOnRequests");
                            c.MapLeftKey("RequestID");
                            c.MapRightKey("ItemID");
                        });
        }
    }
}