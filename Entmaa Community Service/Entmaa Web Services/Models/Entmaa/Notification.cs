using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Notification
    {
        public int ID { get; set; }

        public int DeliveredTo { get; set; }

        public bool IsSeen { get; set; }

        public int TypeID { get; set; }

        public int TriggerID { get; set; }

        public string Message { get; set; }

        public NotificationType NotificationType { get; set; }
    }

    public class NotificationType
    {
        public NotificationType()
        {
            Notifications = new HashSet<Notification>();
        }

        public int ID { get; set; }

        public string Description { get; set; }

        public ICollection<Notification> Notifications { get; set; }
    }
}