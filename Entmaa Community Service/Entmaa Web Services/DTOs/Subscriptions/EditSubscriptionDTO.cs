using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Subscriptions
{
    public class EditSubscriptionDTO
    {
        public int DaysInterval { get; set; }

        public int CashAmount { get; set; }
    }
}