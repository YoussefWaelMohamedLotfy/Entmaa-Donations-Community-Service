using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class DonatedItem
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public bool IsDelivered { get; set; }
        
        public int DonatedBy { get; set; }
        
        public int DonatedTo { get; set; }

        public ICollection<DonatedItemPhoto> DonatedItemPhotos { get; set; }
        public ICollection<ItemsDonationsOnRequest> ItemsDonationsOnRequests { get; set; }
        public ICollection<CollectedItemDonations> collectedItemDonations { get; set; }

    }
}