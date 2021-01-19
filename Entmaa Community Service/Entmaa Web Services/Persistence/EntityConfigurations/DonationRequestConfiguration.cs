using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class DonationRequestConfiguration:EntityTypeConfiguration<DonationRequest>
    {
        public DonationRequestConfiguration()
        {
            Property(d => d.Title).IsRequired();           
            HasKey(d => d.PostID);
            HasMany(d => d.MoneyDonationsOnRequests).WithRequired(m => m.DonationRequest).HasForeignKey(m => m.RequestId);
            HasMany(d => d.ItemsDonationsOnRequests).WithRequired(i => i.DonationRequest).HasForeignKey(i => i.RequestId);
            HasRequired(d => d.Post).WithRequiredDependent(p => p.DonationRequest);
        }
    }
}