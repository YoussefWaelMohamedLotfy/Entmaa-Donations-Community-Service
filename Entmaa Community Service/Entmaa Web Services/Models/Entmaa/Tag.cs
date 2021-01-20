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

        public ICollection<Auction> AuctionTags { get; set; }
        
        public ICollection<Post> PostTags { get; set; }

        public ICollection<Event> EventTags { get; set; }

        public ICollection<User> UserTags { get; set; }
        public ICollection<ReportedItemTag> ReportedItemTags{ get; set; }
        public ICollection<DonatedItemTag> DonatedItemTags { get; set; }
    }


    // To be deleted
    public class ReportedItemTag
    {
        public int ItemID { get; set; }
        public int TagID { get; set; }
        public Tag Tag { get; set; }
        public ReportedItem ReportedItem { get; set; }
    }

    public class DonatedItemTag
    {
        public int ItemID { get; set; }
        public int TagID { get; set; }
        public DonatedItem donatedItem { get; set; }

        public Tag Tag { get; set; }

    }
}