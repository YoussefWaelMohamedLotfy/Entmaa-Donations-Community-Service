using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.EntityConfigurations
{
    /*  public class PhotoConfiguration : EntityTypeConfiguration<Photo>
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
              HasRequired(p => p.postPhoto).WithRequiredPrincipal(p => p.Photo);
              HasRequired(p => p.donatedItemPhoto).WithRequiredPrincipal(p => p.Photo);

          }
      }
      */

    public class UserPhotosConfiguration : EntityTypeConfiguration<UserPhotos>
    {
        public UserPhotosConfiguration()
        {
            HasKey(u => new { u.UserID, u.PhotoURL });
            Property(p => p.PhotoURL).IsRequired().IsMaxLength();
        }
    }
    public class PostPhotosConfiguration: EntityTypeConfiguration<PostPhoto>
    {
        public PostPhotosConfiguration()
        {
            HasKey(p => new { p.PostID, p.PhotoURL });
            Property(p => p.PhotoURL).IsRequired().IsMaxLength();

        }
    }

    public class DonatedItemPhotosConfiguration: EntityTypeConfiguration<DonatedItemPhoto>
    {
        public DonatedItemPhotosConfiguration()
        {
            HasKey(p => new { p.ItemID, p.PhotoURL });
            Property(p => p.PhotoURL).IsRequired().IsMaxLength();
        }
    }

    public class AuctionItemPhotosConfiguration:EntityTypeConfiguration<AuctionItemPhoto>
    {
        public AuctionItemPhotosConfiguration()
        {
            HasKey(a => new { a.AuctionID, a.PhotoURL });
            Property(p => p.PhotoURL).IsRequired().IsMaxLength();
        }
    }

    public class ReportedItemsPhotosConfiguration:EntityTypeConfiguration<ReportedItemPhoto>
    {
        public ReportedItemsPhotosConfiguration()
        {
            HasKey(r => new { r.ItemID, r.PhotoURL });
            Property(p => p.PhotoURL).IsRequired().IsMaxLength();
        }
    }

    public class OrganizationsAlbumPhotosConfiguration:EntityTypeConfiguration<OrganizationAlbumPhoto>
    {
        public OrganizationsAlbumPhotosConfiguration()
        {
            HasKey(o => new { o.OrganizationID, o.PhotoURL });
            Property(p => p.PhotoURL).IsRequired().IsMaxLength();
        }
    }


}