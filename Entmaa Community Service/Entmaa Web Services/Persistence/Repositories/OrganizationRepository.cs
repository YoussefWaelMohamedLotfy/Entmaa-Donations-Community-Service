using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Models.Entmaa;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }
        public OrganizationRepository(DbContext context) : base(context)
        {
        }

        public Organization GetOrganization(int id)
        {
            return MainContext.Organizations
                    .Include(c=>c.Tags)
                    .SingleOrDefault(c => c.ID == id);
        }

        public IEnumerable<Organization> GetAllOrganizations()
        {
            return MainContext.Organizations.ToList();
        }

        public Organization ModifyOrganization(int id)
        {
            var OrganizationInDB = MainContext.Organizations
                .Include(c => c.Tags)
                .SingleOrDefault(O => O.ID == id);
            return OrganizationInDB;
        }

        public Organization Login(string email, string password)
        {
            return MainContext.Organizations
                .SingleOrDefault(o => o.Email == email && o.Password == password);
        }
    }
}
 