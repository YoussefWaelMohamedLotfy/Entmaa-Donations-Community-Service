using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class PostCommentsConfiguration:EntityTypeConfiguration<PostComments>
    {
        public PostCommentsConfiguration()
        {
            Property(p => p.PostId).IsRequired();
            Property(p => p.UserID).IsRequired();
            Property(p => p.Comment).IsRequired();
            Property(p => p.DateCommented).IsRequired();
        }
    }
}