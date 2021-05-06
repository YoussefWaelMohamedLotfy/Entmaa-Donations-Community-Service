using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.DTOs.Donations;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.DTOs.Auctions
{
    public class GetAuctionsDTO
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int StartPrice { get; set; }

        public int SoldPrice { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public UserDTO OrganizationCreator { get; set; }
    }
}