using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class ReportedCaseRepository : Repository<ReportedCase>, IReportedCaseRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public ReportedCaseRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<ReportedCase> GetReportedCasesToOrganization(int id)
        {
            return MainContext.ReportedCases
                .Where(c => c.ReportedTo == id)
                .ToList();
        }
    }
}