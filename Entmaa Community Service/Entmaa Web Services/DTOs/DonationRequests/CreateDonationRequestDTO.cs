using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.DonationRequests
{
    public class CreateDonationRequestDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int MoneyReceivedAmount { get; set; }

        public bool ItemsAccepted { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }
    }
}