using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class UserTypeConfiguration : EntityTypeConfiguration<UserType>
    {
        public UserTypeConfiguration()
        {
            Property(u => u.Name).IsRequired();

            HasMany(u => u.Users).WithRequired(u => u.UserType).HasForeignKey(u => u.UserTypeID);
        }
    }
}