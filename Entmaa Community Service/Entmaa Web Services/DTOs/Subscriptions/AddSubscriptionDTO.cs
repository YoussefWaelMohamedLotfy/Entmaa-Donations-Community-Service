using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Subscriptions
{
    public class AddSubscriptionDTO
    {
        public int SubscribedTo { get; set; }

        public int DaysInterval { get; set; }

        public DateTime StartDate { get; set; }

        public int CashAmount { get; set; }
    }
}