using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class ItemsDonationsOnRequest
    {
        public int ItemID { get; set; }

        public int RequestId { get; set; }
      
        public DonationRequest DonationRequest { get; set; }

        public DonatedItem DonatedItem { get; set; }

    }
}