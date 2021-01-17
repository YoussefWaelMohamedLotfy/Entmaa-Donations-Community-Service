using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class PostTypeConfiguration : EntityTypeConfiguration<PostType>
    {
        public PostTypeConfiguration()
        {
            Property(p => p.Name).IsRequired();

            HasMany(p => p.Posts).WithRequired(p => p.PostType).HasForeignKey(p => p.PostTypeID);
        }
    }
}