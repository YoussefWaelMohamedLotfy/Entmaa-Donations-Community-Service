using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class DonationType
    {
        public DonationType()
        {
            DonationRequests = new HashSet<DonationRequest>();
        }

        public byte ID { get; set; }

        public string Name { get; set; }

        public ICollection<DonationRequest> DonationRequests { get; set; }
    }
}