using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class MoneyDonationsOnRequestConfiguration : EntityTypeConfiguration<MoneyDonationsOnRequest>
    {
        public MoneyDonationsOnRequestConfiguration()
        {
            HasKey(m => m.ID);

            Property(m => m.DonationToken).IsRequired();
        }
    }
}