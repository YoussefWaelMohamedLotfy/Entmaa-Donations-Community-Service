using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Core.Repositories
{
    public interface IDonationRequestRepository : IRepository<DonationRequest>
    {
        DonationRequest GetDonationRequest(int id);
        IEnumerable<MoneyDonationOnRequest> GetMoneyDonationsOnRequest(int id);
        IEnumerable<DonationRequest> GetOrganizationDonationRequests(int id);
        IEnumerable<Post> GetPosts(int id);
    }
}
