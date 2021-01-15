using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.Email).IsRequired();
            Property(u => u.Password).IsRequired();
            Property(u => u.Name).IsRequired();
            Property(u => u.FirebaseToken).IsRequired();
        }
    }

    public class ContributorConfiguration : EntityTypeConfiguration<Contributor>
    {
        public ContributorConfiguration()
        {
            ToTable("Contributors");
            Property(c => c.ID).HasColumnName("UserID");
            Property(c => c.Gender).IsRequired();
        }
    }

    public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration()
        {
            ToTable("Organizations");
            Property(o => o.ID).HasColumnName("UserID");
            Property(o => o.FawryToken).IsRequired();
        }
    }
}