using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Auctions
{
    public class CreateAuctionDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int StartPrice { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }
    }
}