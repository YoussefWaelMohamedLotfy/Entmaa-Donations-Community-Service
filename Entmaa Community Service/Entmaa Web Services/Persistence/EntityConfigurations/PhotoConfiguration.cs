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

    public class UserPhotoConfiguration : EntityTypeConfiguration<UserPhoto>
    {
        public UserPhotoConfiguration()
        {
            HasKey(u => new { u.UserID, u.type });

            Property(p => p.PhotoURL).IsRequired().IsMaxLength();
        }
    }

    public class PostPhotoConfiguration: EntityTypeConfiguration<PostPhoto>
    {
        public PostPhotoConfiguration()
        {
            HasKey(p => new { p.PostID, p.PhotoURL });

            Property(p => p.PhotoURL).IsRequired().IsMaxLength();

        }
    }

    public class DonatedItemPhotoConfiguration: EntityTypeConfiguration<DonatedItemPhoto>
    {
        public DonatedItemPhotoConfiguration()
        {
            HasKey(p => new { p.ItemID, p.PhotoURL });

            Property(p => p.PhotoURL).IsRequired().IsMaxLength();
        }
    }

    public class AuctionItemPhotoConfiguration:EntityTypeConfiguration<AuctionItemPhoto>
    {
        public AuctionItemPhotoConfiguration()
        {
            HasKey(a => new { a.AuctionID, a.PhotoURL });

            Property(p => p.PhotoURL).IsRequired().IsMaxLength();
        }
    }

    public class ReportedItemsPhotoConfiguration:EntityTypeConfiguration<ReportedItemPhoto>
    {
        public ReportedItemsPhotoConfiguration()
        {
            HasKey(r => new { r.ItemID, r.PhotoURL });

            Property(p => p.PhotoURL).IsRequired().IsMaxLength();
        }
    }

    public class OrganizationsAlbumPhotoConfiguration:EntityTypeConfiguration<OrganizationAlbumPhoto>
    {
        public OrganizationsAlbumPhotoConfiguration()
        {
            HasKey(o => new { o.OrganizationID, o.PhotoURL });

            Property(p => p.PhotoURL).IsRequired().IsMaxLength();
        }
    }


}