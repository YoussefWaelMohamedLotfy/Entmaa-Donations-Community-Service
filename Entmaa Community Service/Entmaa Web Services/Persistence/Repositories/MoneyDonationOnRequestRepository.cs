using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class MoneyDonationOnRequestRepository : Repository<MoneyDonationOnRequest>, IMoneyDonationOnRequestRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public MoneyDonationOnRequestRepository(MainContext context) : base(context)
        {

        }
    }
}