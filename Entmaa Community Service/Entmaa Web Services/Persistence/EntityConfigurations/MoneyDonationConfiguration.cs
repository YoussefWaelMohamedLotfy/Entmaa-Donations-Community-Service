using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;


namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class MoneyDonationConfiguration:EntityTypeConfiguration<MoneyDonation>
    {
        public MoneyDonationConfiguration()
        {
            HasKey(m => m.ID);

            Property(m => m.DonationToken).IsRequired();
        }
    }
}