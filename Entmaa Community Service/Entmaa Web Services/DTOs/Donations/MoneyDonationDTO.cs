using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Donations
{
    public class MoneyDonationDTO
    {
        public int ContributorID { get; set; }

        public int OrganizationID { get; set; }

        public int MoneyAmount { get; set; }

        public string DonationToken { get; set; }
    }
}