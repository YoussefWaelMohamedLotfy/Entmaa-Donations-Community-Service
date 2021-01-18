using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    public class PhotoConfiguration : EntityTypeConfiguration<Photo>
    {
        public PhotoConfiguration()
        {
            HasKey(p => p.ID);
            Property(p => p.Path).IsRequired();
            HasRequired(p => p.UserProfile).WithRequiredPrincipal(p => p.ProfilePhoto);
            HasRequired(p => p.UserCover).WithRequiredPrincipal(p => p.CoverPhoto);
            HasRequired(p => p.OrganizationAlbumPhoto).WithRequiredPrincipal(p => p.Photo);
            HasRequired(p => p.ReportedItemPhoto).WithRequiredPrincipal(p => p.Photo);
            HasRequired(p => p.auctionItemPhoto).WithRequiredPrincipal(p => p.Photo);
            HasRequired(p => p.postPhoto).WithOptional(p => p.Photo);
            HasRequired(p => p.donatedItemPhoto).WithOptional(p => p.Photo);
            
        }
    }

    public class PostPhotosConfiguration: EntityTypeConfiguration<PostPhoto>
    {
        public PostPhotosConfiguration()
        {
            HasKey(p => new { p.PostID, p.PhotoID });
        }
    }

    public class DonatedItemPhotosConfiguration: EntityTypeConfiguration<DonatedItemPhoto>
    {
        public DonatedItemPhotosConfiguration()
        {
            HasKey(p => new { p.ItemID, p.PhotoID });
        }
    }

    public class AuctionItemPhotosConfiguration:EntityTypeConfiguration<AuctionItemPhoto>
    {
        public AuctionItemPhotosConfiguration()
        {
            HasKey(a => new { a.AuctionID, a.PhotoID });
        }
    }

    public class ReportedItemsPhotosConfiguration:EntityTypeConfiguration<ReportedItemPhoto>
    {
        public ReportedItemsPhotosConfiguration()
        {
            HasKey(r => new { r.ItemID, r.PhotoID });
        }
    }

    public class OrganizationsAlbumPhotosConfiguration:EntityTypeConfiguration<OrganizationAlbumPhoto>
    {
        public OrganizationsAlbumPhotosConfiguration()
        {
            HasKey(o => new { o.OrganizationID, o.PhotoID });
        }
    }


}