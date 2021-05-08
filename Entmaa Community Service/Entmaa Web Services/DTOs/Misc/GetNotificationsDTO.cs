using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Misc
{
    public class GetNotificationsDTO
    {
        public int ID { get; set; }

        public bool IsSeen { get; set; }
        
        public int TypeID { get; set; }

        public int TriggerID { get; set; }

        public string Message { get; set; }
    }
}