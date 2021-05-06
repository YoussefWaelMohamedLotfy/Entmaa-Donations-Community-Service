using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class PostPhoto
    {
        public int PostID { get; set; }

        public string PhotoURL { get; set; }

        public Post Post { get; set; }
    }

    public class DonatedItemPhoto
    {
        public int ItemID { get; set; }

        public string PhotoURL { get; set; }

        public DonatedItem DonatedItem { get; set; }
    }

    public class ReportedItemPhoto
    {
        public int ItemID { get; set; }

        public string PhotoURL { get; set; }

        public ReportedItem ReportedItem { get; set; }
    }

    public class AuctionItemPhoto
    {
        public int AuctionID { get; set; }

        public string PhotoURL { get; set; }

        public Auction Auction { get; set; }
    }

    public class OrganizationAlbumPhoto
    {
        public int OrganizationID { get; set; }

        public string PhotoURL { get; set; }

        public Organization Organization { get; set; }
    }
}