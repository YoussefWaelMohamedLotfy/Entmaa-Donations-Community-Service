using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Auctions
{
    public class EditAuctionDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime EndDate { get; set; }
    }
}