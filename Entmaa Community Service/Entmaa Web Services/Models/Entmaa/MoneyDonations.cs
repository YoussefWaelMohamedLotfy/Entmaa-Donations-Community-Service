using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class MoneyDonations
    {
        public int Id { get; set; }
        public int ContributorId { get; set; }
        public int OrganizationId { get; set; }
        public int MoneyaAmount { get; set; }
        public string DonationToken { get; set; }

    }
}