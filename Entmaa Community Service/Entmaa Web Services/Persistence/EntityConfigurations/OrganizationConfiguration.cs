using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration()
        {
            ToTable("Organizations");

            Property(o => o.ID).HasColumnName("UserID");
            Property(o => o.FawryToken).IsRequired();

            HasMany(o => o.Posts).WithRequired(o => o.Organization).HasForeignKey(o => o.PostedBy);
            HasMany(o => o.AuctionsCreated).WithRequired(a => a.OrganizationCreator).HasForeignKey(o => o.HostedBy);
        }
    }
}