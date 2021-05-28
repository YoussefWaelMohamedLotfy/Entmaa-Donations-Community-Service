using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.DTOs.Donations;

namespace Entmaa_Web_Services.DTOs.DonationRequests
{
    public class DonationRequestDTO
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int PostedBy { get; set; }
    }
}