using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class DonationTypes
    {
        public int ID { get; set; }
        public string name { get; set; }
        public ICollection<DonationRequest> DonationRequests { get; set; }
    }
}