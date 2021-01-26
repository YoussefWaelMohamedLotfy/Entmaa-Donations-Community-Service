using System.Data.Entity.ModelConfiguration;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class UserPhotoConfiguration : EntityTypeConfiguration<UserPhoto>
    {
        public UserPhotoConfiguration()
        {
            HasKey(u => new { u.UserID, u.PhotoType });

            Property(p => p.PhotoURL).IsRequired().HasMaxLength(450);
        }
    }

    public class PostPhotoConfiguration : EntityTypeConfiguration<PostPhoto>
    {
        public PostPhotoConfiguration()
        {
            HasKey(p => new { p.PostID, p.PhotoURL });

            Property(p => p.PhotoURL).IsRequired().HasMaxLength(450);
        }
    }

    public class DonatedItemPhotoConfiguration : EntityTypeConfiguration<DonatedItemPhoto>
    {
        public DonatedItemPhotoConfiguration()
        {
            HasKey(p => new { p.ItemID, p.PhotoURL });

            Property(p => p.PhotoURL).IsRequired().HasMaxLength(450);
        }
    }

    public class AuctionItemPhotoConfiguration : EntityTypeConfiguration<AuctionItemPhoto>
    {
        public AuctionItemPhotoConfiguration()
        {
            HasKey(a => new { a.AuctionID, a.PhotoURL });

            Property(p => p.PhotoURL).IsRequired().HasMaxLength(450);
        }
    }

    public class ReportedItemsPhotoConfiguration : EntityTypeConfiguration<ReportedItemPhoto>
    {
        public ReportedItemsPhotoConfiguration()
        {
            HasKey(r => new { r.ItemID, r.PhotoURL });

            Property(p => p.PhotoURL).IsRequired().HasMaxLength(450);
        }
    }

    public class OrganizationsAlbumPhotoConfiguration : EntityTypeConfiguration<OrganizationAlbumPhoto>
    {
        public OrganizationsAlbumPhotoConfiguration()
        {
            HasKey(o => new { o.OrganizationID, o.PhotoURL });

            Property(p => p.PhotoURL).IsRequired().HasMaxLength(450);
        }
    }
}