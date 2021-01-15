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
            //HasOptional(c => c.Contributor).WithRequired(c => c.User).Map(c => c.MapKey("UserID"));
            //HasOptional(c => c.Organization).WithRequired(c => c.User).Map(c => c.MapKey("UserID"));
            HasRequired(c => c.Organization).WithRequiredPrincipal(c => c.User);
            HasRequired(c => c.Contributor).WithRequiredPrincipal(c => c.User);

        }
    }

    public class ContributorConfiguration : EntityTypeConfiguration<Contributor>
    {
        public ContributorConfiguration()
        {
            ToTable("Contributors");
            //HasRequired(c => c.User).WithRequiredDependent(c => c.Contributor);
        }
    }

    public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration()
        {
            ToTable("Organizations");
            //HasRequired(c => c.User).WithRequiredDependent(c => c.Organization);
        }
    }
}