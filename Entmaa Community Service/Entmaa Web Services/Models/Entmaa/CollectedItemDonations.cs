using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class CollectedItemDonations
    {
        public int OrganizationId { get; set; }
        public int ItemID { get; set; }
        public Organization organization { get; set; }
        public DonatedItem DonatedItem { get; set; }
    }
}