using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Auctions
{
    public class CreateBidderDTO
    {
        public int BidBy { get; set; }

        public int Price { get; set; }
    }
}