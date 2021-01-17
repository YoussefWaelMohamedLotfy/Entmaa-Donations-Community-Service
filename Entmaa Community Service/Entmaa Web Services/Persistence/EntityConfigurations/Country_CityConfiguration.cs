using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            Property(c => c.Name).IsRequired();

            HasMany(c => c.Cities).WithRequired(c => c.Country).HasForeignKey(c => c.CountryID);
        }
    }

    public class CityConfiguration : EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            Property(c => c.Name).IsRequired();

            HasMany(c => c.Locations).WithRequired(u => u.City).HasForeignKey(u => u.CityID);
        }
    }
}