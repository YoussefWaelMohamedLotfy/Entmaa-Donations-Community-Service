using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class AuctionBidder
    {
        public int AuctionID { get; set; }

        public int BidBy { get; set; }

        public int Price { get; set; }

        public string FawryToken { get; set; }

        public DateTime ValidUntil { get; set; }

        public bool IsPaid { get; set; }

        public Auction Auction { get; set; }

        public Contributor Contributor { get; set; }
    }
}