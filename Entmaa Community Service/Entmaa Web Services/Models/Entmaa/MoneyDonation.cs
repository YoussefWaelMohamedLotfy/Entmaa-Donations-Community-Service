using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class MoneyDonation
    {
        public int ID { get; set; }

        public int ContributorID { get; set; }
        
        public int OrganizationID { get; set; }
        
        public int MoneyAmount { get; set; }
        
        public string DonationToken { get; set; }

        public Contributor Contributor { get; set; }

        public Organization Organization { get; set; }
    }
}