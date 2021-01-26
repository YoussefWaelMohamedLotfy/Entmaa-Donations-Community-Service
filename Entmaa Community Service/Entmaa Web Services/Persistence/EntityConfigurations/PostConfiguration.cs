using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            Property(p => p.Description).IsRequired().IsMaxLength();

            HasMany(p => p.UsersReacted).WithMany(u => u.PostsReactedTo)
                .Map(c =>
                       {
                           c.ToTable("PostLikes");
                           c.MapLeftKey("PostID");
                           c.MapRightKey("UserID");
                       });

            HasRequired(p => p.DonationRequest).WithRequiredPrincipal(d => d.Post);

            HasMany(p => p.PostPhotos).WithRequired(p => p.Post).HasForeignKey(p => p.PostID);
            HasMany(p => p.PostComments).WithRequired(p => p.Post).HasForeignKey(p => p.PostID);

        }
    }
}