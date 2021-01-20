using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
   /* public class Photo
    {
        public int ID { get; set; }
        public string Path { get; set; }
 
        public User UserProfile { get; set; }
        public User UserCover { get; set; }
        public OrganizationAlbumPhoto OrganizationAlbumPhoto { get; set; }
        public ReportedItemPhoto ReportedItemPhoto { get; set; }
        public AuctionItemPhoto auctionItemPhoto { get; set; }
        public PostPhoto postPhoto { get; set; }
        public DonatedItemPhoto donatedItemPhoto { get; set; }


    }
    */



    public class UserPhotos
    {
        public int UserID { get; set; }
        public string PhotoURL { get; set; }
        public User User { get; set; }
    }
    public class PostPhoto
    {
        public int PostID { get; set; }
        public string PhotoURL { get; set; }
        //  public Photo Photo { get; set; }
        public Post Post { get; set; }
    }

    public class DonatedItemPhoto
    {
        public int ItemID { get; set; }
        public string PhotoURL { get; set; }
        // public Photo Photo { get; set; }

        public DonatedItem DonatedItem { get; set; }
    }

    public class ReportedItemPhoto
    {
        public int ItemID { get; set; }
        public string PhotoURL { get; set; }
        // public Photo Photo { get; set; }

        public ReportedItem ReportedItem { get; set; }
    }

    public class AuctionItemPhoto
    {
        public int AuctionID { get; set; }
        public string PhotoURL { get; set; }
        // public Photo Photo { get; set; }

        public Auction Auction { get; set; }
    }

    public class OrganizationAlbumPhoto
    {
        public int OrganizationID { get; set; }
        public string PhotoURL { get; set; }
        // public Photo Photo { get; set; }

        public Organization organization { get; set; }
    }
}