using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Photo
    {
        public int ID { get; set; }
        public string Path { get; set; }
    }

    public class PostPhoto
    {
        public int PostID { get; set; }
        public int PhotoID { get; set; }
    }

    public class DonatedItemPhoto
    {
        public int ItemID { get; set; }
        public int PhotoID { get; set; }
    }

    public class ReportedItemPhoto
    {
        public int ItemID { get; set; }
        public int PhotoID { get; set; }
    }

    public class AuctionItemPhoto
    {
        public int AuctionID { get; set; }
        public int PhotoID { get; set; }
    }

    public class OrganizationAlbumPhoto
    {
        public int OrganizationID { get; set; }
        public int PhotoID { get; set; }
    }
}