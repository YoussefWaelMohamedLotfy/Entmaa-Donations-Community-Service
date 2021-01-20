using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class MoneyDonationOnRequest
    {
        public int ID { get; set; }

        public int ContributorID { get; set; }

        public int RequestID { get; set; }

        public int MoneyAmount { get; set; }

        public string DonationToken { get; set; }

        public DonationRequest DonationRequest { get; set; }

        public Contributor Contributor { get; set; }
    }
}