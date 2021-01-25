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

            HasMany(u => u.Locations).WithRequired(u => u.User).HasForeignKey(u => u.UserID);
            HasMany(u => u.PhoneNumbers).WithRequired(u => u.User).HasForeignKey(u => u.UserID);
            HasMany(u => u.PostComments).WithRequired(p => p.User).HasForeignKey(p => p.UserID);
            HasRequired(u => u.UserProfilePhoto).WithRequiredDependent(p => p.UserProfilePhoto);
            HasRequired(u => u.UserCoverPhoto).WithRequiredDependent(p => p.UserCoverPhoto);

        }
    }
}