using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class AuctionBidderRepository : Repository<AuctionBidder>, IAuctionBidderRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public AuctionBidderRepository(MainContext context) : base(context)
        {

        }

        public AuctionBidder GetBidder(int id)
        {
            return MainContext.AuctionBidders
                .Include(b => b.Auction)
                .Include(b => b.Contributor)
                .SingleOrDefault(b => b.BidBy == id);
        }
    }
}