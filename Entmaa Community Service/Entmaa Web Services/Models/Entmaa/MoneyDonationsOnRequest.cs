using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class MoneyDonationsOnRequest
    {
        public int Id { get; set; }
        public int ContributorId { get; set; }
        public int RequestId { get; set; }
        public int MoneyAmount { get; set; }
        public string DonationToken { get; set; }

        public DonationRequest DonationRequest { get; set; }
        public Contributor Contributor { get; set; }
    }
}