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

        public Organization Organization { get; set; }

        public Contributor Contributor { get; set; }

        public ICollection<DonatedItemPhoto> DonatedItemPhotos { get; set; }

        public ICollection<ItemsDonationOnRequest> ItemsDonationsOnRequests { get; set; }

        public ICollection<CollectedItemDonation> CollectedItemDonations { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}