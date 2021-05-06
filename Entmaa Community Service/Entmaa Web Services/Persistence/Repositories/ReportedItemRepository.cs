using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class ReportedItemRepository : Repository<ReportedItem>, IReportedItemRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public ReportedItemRepository(MainContext context) : base(context)
        {

        }

        public IEnumerable<ReportedItem> GetAllReportedItems()
        {
            return MainContext.ReportedItems.ToList();
        }

        public IEnumerable<ReportedItem> GetContributorReportedItems(int id)
        {
            return MainContext.ReportedItems
                .Where(c => c.CreatedBy == id)
                .ToList();
        }

        public ReportedItem GetReportedItem(int itemId)
        {
            return MainContext.ReportedItems
                .Include(c => c.ContributorResolved)
                .SingleOrDefault(c => c.ID == itemId);
        }
    }
}