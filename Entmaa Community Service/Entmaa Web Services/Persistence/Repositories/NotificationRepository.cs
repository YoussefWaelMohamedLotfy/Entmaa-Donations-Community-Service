using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public NotificationRepository(DbContext context) : base(context)
        {
        }
        
        public IEnumerable<Notification> GetUserNotifications(int id)
        {
            return MainContext.Notifications
                .Where(n => n.DeliveredTo == id)
                .ToList();
        }
    }
}