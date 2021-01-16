using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(t => t.Name).IsRequired();

            HasMany(t => t.AuctionTags).WithMany(a => a.Tags)
                .Map(c =>
                        {
                            c.ToTable("AuctionTags");
                            c.MapLeftKey("TagID");
                            c.MapRightKey("AuctionID");
                        });

            HasMany(t => t.PostTags).WithMany(p => p.Tags)
                .Map(c =>
                        {
                            c.ToTable("PostTags");
                            c.MapLeftKey("TagID");
                            c.MapRightKey("PostID");
                        });

            HasMany(t => t.EventTags).WithMany(e => e.Tags)
                .Map(c =>
                        {
                            c.ToTable("EventTags");
                            c.MapLeftKey("TagID");
                            c.MapRightKey("EventID");
                        });

            HasMany(t => t.UserTags).WithMany(u => u.Tags)
                .Map(c =>
                        {
                            c.ToTable("UserTags");
                            c.MapLeftKey("TagID");
                            c.MapRightKey("UserID");
                        });
        }
    }
}