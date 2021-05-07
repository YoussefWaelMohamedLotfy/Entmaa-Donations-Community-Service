using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class DonatedItem
    {
        public DonatedItem()
        {
            Donations = new HashSet<DonationRequest>();
            Organizations = new HashSet<Organization>();
            Tags = new HashSet<Tag>();
        }

        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public bool IsDelivered { get; set; }
        
        public int DonatedBy { get; set; }
        
        public int DonatedTo { get; set; }

        public string ItemPhotoUrl { get; set; }

        public Organization Organization { get; set; }

        public Contributor Contributor { get; set; }

        public ICollection<DonationRequest> Donations { get; set; }

        public ICollection<Organization> Organizations { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}