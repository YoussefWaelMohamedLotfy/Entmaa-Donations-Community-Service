using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.DTOs.Donations;

namespace Entmaa_Web_Services.DTOs.Subscriptions
{
    public class GetSubscriptionsDTO
    {
        public UserDTO Organization { get; set; }

        public int DaysInterval { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime RenewalDate { get; set; }

        public int CashAmount { get; set; }
    }
}