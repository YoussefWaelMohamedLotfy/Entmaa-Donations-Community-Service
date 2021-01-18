using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;
namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class ReportedItemsConfiguration:EntityTypeConfiguration<ReportedItem>
    {
        public ReportedItemsConfiguration()
        {
            HasMany(r => r.reportedItemPhotos).WithRequired(r => r.ReportedItem).HasForeignKey(r => r.ItemID);
        }
    }
}