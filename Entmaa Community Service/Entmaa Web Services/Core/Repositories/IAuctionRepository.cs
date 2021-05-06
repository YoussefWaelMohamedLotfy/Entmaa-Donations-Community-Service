using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Core.Repositories
{
    public interface IAuctionRepository : IRepository<Auction>
    {
        Auction GetAuction(int id);
        IEnumerable<Auction> GetAllAuctions();
        IEnumerable<Auction> GetContributorBiddedAuctions(int id);
        IEnumerable<Auction> GetOrganizationAuctions(int id);
        AuctionBidder GetAuctionWinner(int id);
    }
}
