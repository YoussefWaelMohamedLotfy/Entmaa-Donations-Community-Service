using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class MoneyDonationsOnRequestConfiguration:EntityTypeConfiguration<MoneyDonationsOnRequest>
    {
        public MoneyDonationsOnRequestConfiguration()
        {

            HasKey(m => new { m.ContributorId, m.RequestId });
            Property(m => m.DonationToken).IsRequired();

        }
    }
}