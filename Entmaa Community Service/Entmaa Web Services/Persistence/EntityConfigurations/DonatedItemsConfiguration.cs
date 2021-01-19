using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class DonatedItemsConfiguration:EntityTypeConfiguration<DonatedItem>
    {
        public DonatedItemsConfiguration()
        {
            HasKey(d => d.ID);
            HasMany(d => d.DonatedItemPhotos).WithRequired(d => d.DonatedItem).HasForeignKey(d => d.ItemID);
            HasMany(d => d.ItemsDonationsOnRequests).WithRequired(i => i.DonatedItem).HasForeignKey(i => i.ItemID);
        }
    }
}