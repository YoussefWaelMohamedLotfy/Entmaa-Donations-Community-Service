using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class DonationRequest
    {
        public DonationRequest()
        {
            MoneyDonationsOnRequest = new HashSet<MoneyDonationOnRequest>();
            Items = new HashSet<DonatedItem>();
        }

        public int PostID { get; set; }
        
        public string Title { get; set; }
        
        public int MoneyNeededAmount { get; set; }
        
        public int MoneyReceivedAmount { get; set; }

        public int ItemsNeededCount { get; set; }

        public int ItemsReceivedCount { get; set; }

        public byte DonationTypeID { get; set; }

        public bool IsFulfilled { get; set; }

        public Post Post { get; set; }

        public DonationType DonationType { get; set; }

        public ICollection<MoneyDonationOnRequest> MoneyDonationsOnRequest { get; set; }

        public ICollection<DonatedItem> Items { get; set; }
    }
}