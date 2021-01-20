using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class DonationTypesConfiguration:EntityTypeConfiguration<DonationTypes>
    {
        public DonationTypesConfiguration()
        {
            Property(d => d.Name).IsRequired();

            HasKey(d => d.ID);

            HasMany(d => d.DonationRequests).WithRequired(d => d.DonationType).HasForeignKey(d => d.DonationTypeID);
        }
    }
}