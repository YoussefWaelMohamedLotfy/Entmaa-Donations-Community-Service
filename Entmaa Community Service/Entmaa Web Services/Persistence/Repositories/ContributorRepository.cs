using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class ContributorRepository : Repository<Contributor>, IContributorRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public ContributorRepository(MainContext context) : base(context)
        {
                
        }

        public Contributor GetContributorProfile(int id)
        {
            return MainContext.Contributors
                .Include(c => new { c.Tags, c.Locations })
                .SingleOrDefault(c => c.ID == id);
        }
    }
}