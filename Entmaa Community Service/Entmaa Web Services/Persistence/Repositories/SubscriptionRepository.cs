using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public SubscriptionRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Subscription> GetContributorSubscriptions(int id)
        {
            return MainContext.Subscriptions
                .Include(s => s.Organization)
                .Where(s => s.SubscribedBy == id)
                .ToList();
        }
    }
}