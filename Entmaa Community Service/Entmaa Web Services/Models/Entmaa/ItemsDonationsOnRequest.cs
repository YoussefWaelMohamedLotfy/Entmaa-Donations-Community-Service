using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class ItemsDonationsOnRequest
    {
        public int ContributorId { get; set; }
        public int RequestId { get; set; }
        public int DonatedItemId { get; set; }
        public int ItemsAmount { get; set; }
       
        public DonationRequest DonationRequest { get; set; }
        public Contributor contributor { get; set; }

    }
}