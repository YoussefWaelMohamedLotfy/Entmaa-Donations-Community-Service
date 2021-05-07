using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class AuctionRepository : Repository<Auction>, IAuctionRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public AuctionRepository(MainContext context) : base(context)
        {

        }

        public Auction GetAuction(int id)
        {
            return MainContext.Auctions
                .Include(a => a.Bidders)
                .Include(a => a.OrganizationCreator)
                .SingleOrDefault(a => a.ID == id);
        }

        public IEnumerable<Auction> GetAllAuctions()
        {
            return MainContext.Auctions
                .Include(a => a.Bidders)
                .Include(a => a.OrganizationCreator)
                .ToList();
        }

        public IEnumerable<Auction> GetContributorBiddedAuctions(int id)
        {
            var bidders = MainContext.AuctionBidders
                .Include(b => b.Contributor)
                .Include(b => b.Auction)
                .Where(b => b.BidBy == id)
                .ToList();

            List<Auction> auctions = new List<Auction>();

            foreach (var bidder in bidders)
            {
                auctions.Add(bidder.Auction);
            }

            return auctions;
        }

        public IEnumerable<Auction> GetOrganizationAuctions(int id)
        {
            return MainContext.Auctions
                .Include(a => a.Bidders)
                .Include(a => a.OrganizationCreator)
                .Where(a => a.HostedBy == id)
                .ToList();
        }

        public Contributor GetAuctionWinner(int id)
        {
            int highestPrice = MainContext.AuctionBidders.Max(b => b.Price);

            var bidder = MainContext.AuctionBidders
                                .Include(c => c.Auction)
                                .Include(c => c.Contributor)
                                .SingleOrDefault(c => c.Price == highestPrice && c.Auction.ID == id);

            return bidder.Contributor;
        }
    }
}