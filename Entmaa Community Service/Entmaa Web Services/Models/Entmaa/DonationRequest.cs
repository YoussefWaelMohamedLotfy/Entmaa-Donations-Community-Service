using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class DonationRequest
    {
        public int PostID { get; set; }
        
        public string Title { get; set; }
        
        public int MoneyNeededAmount { get; set; }
        
        public int MoneyReceivedAmount { get; set; }

        public int ItemesNeededCount { get; set; }

        public int ItemsReceivedCount { get; set; }

        public byte DonationTypeID { get; set; }

        public bool IsFulfilled { get; set; }

        public Post Post { get; set; }

        public DonationType DonationType { get; set; }

        public ICollection<MoneyDonationOnRequest> MoneyDonationsOnRequests { get; set; }

        public ICollection <ItemsDonationOnRequest> ItemsDonationsOnRequests { get; set; }
    }
}