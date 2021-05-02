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

        public Contributor GetContributorProfileCreation(int id)
        {
            return MainContext.Contributors
                .Include(c => c.PhoneNumbers)
                .Include(c => c.Tags)
                .Include(c => c.Locations)
                .Include(c => c.BadgesOwned)
                .SingleOrDefault(c => c.ID == id);
        }

        public Contributor Login(string email, string password)
        {
            return MainContext.Contributors
                .SingleOrDefault(c => c.Email == email && c.Password == password);
        }

        public Contributor GetContributorProfile(int id)
        {
            return MainContext.Contributors
                .Include(c => c.PhoneNumbers)
                .Include(c => c.Tags)
                .Include(c => c.Locations)
                .Include(c => c.BadgesOwned)
                .Include(c => c.DonatedItems)
                .SingleOrDefault(c => c.ID == id);
        }

        public Contributor GetContributorBadges(int id)
        {
            return MainContext.Contributors
                .Include(c => c.BadgesOwned)
                .SingleOrDefault(c => c.ID == id);
        }
    }
}