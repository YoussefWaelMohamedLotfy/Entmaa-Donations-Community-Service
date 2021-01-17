using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class UserPhoneNumberConfiguration : EntityTypeConfiguration<UserPhoneNumber>
    {
        public UserPhoneNumberConfiguration()
        {
            HasKey(u => u.PhoneNumber).Property(u => u.PhoneNumber).HasMaxLength(50);
        }
    }
}