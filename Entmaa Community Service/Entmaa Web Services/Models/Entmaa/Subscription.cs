using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Subscription
    {
        public int ID { get; set; }
 
        public int SubscribedBy { get; set; }
  
        public int SubscribedTo { get; set; }
   
        public int DaysInterval { get; set; }
  
        public DateTime StartDate { get; set; }
  
        public DateTime EndDate { get; set; }
  
        public DateTime RenewalDate { get; set; }
   
        public int CashAmount { get; set; }
   
        public bool IsActive { get; set; }

        public Contributor Contributor { get; set; }

        public Organization Organization { get; set; }
    }
}