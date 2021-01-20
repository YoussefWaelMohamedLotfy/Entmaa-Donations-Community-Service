using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class CollectedItemDonations
    {
        public int OrganizationID { get; set; }

        public int ItemID { get; set; }

        public Organization Organization { get; set; }

        public DonatedItem DonatedItem { get; set; }
    }
}