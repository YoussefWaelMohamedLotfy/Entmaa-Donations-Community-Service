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
        
        public int AmountNeeded { get; set; }
        
        public int AmountReceived { get; set; }
        
        public bool AreItemsAccepted { get; set; }
        
        public bool IsCompleted { get; set; }

        public Post Post { get; set; }

    }

    public class DonationOnRequest
    {
        public int ContibutorID { get; set; }
        
        public int RequestID { get; set; }
        
        public int CashAmount { get; set; }
        
        public string DonationToken { get; set; }
    }
}