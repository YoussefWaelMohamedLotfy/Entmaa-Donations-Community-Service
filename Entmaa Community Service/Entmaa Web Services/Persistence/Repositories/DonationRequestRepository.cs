using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class DonationRequestRepository : Repository<DonationRequest>, IDonationRequestRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public DonationRequestRepository(DbContext context) : base(context)
        {
        }


    }
}