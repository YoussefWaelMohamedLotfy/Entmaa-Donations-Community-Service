using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Tag
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class UserTag
    {
        public int UserID { get; set; }
        public int TagID { get; set; }
    }

    public class ReportedItemTag
    {
        public int ItemID { get; set; }
        public int TagID { get; set; }
    }

    public class PostTag
    {
        public int PostID { get; set; }
        public int TagID { get; set; }
    }

    public class DonatedItemTag
    {
        public int ItemID { get; set; }
        public int TagID { get; set; }
    }

    public class EventTag
    {
        public int EventID { get; set; }
        public int TagID { get; set; }
    }

    public class AuctionTag
    {
        public int AuctionID { get; set; }
        public int TagID { get; set; }
    }
}