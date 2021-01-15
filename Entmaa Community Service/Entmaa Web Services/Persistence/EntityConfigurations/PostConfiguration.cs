﻿using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            HasMany(p => p.UsersReacted).WithMany(u => u.PostsReactedTo)
                .Map(c =>
                       {
                           c.ToTable("PostLikes");
                           c.MapLeftKey("PostID");
                           c.MapRightKey("UserID");
                       });
        }
    }
}