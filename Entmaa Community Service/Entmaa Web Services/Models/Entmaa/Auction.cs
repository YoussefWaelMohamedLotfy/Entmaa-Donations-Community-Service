using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Auction
    {
        public int ID { get; set; }

        public int HostedBy { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int StartPrice { get; set; }

        public int SoldPrice { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Organization OrganizationCreator { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<AuctionBidder> Bidders { get; set; }
    }
}