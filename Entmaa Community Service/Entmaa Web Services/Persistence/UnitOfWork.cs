using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.Persistence.Repositories;

namespace Entmaa_Web_Services.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;

        // Repositories
        public IContributorRepository Contributors { get; private set; }
        public IOrganizationRepository Organizations { get; private set; }
        public IBadgeRepository Badges { get; private set; }
        public IPostRepository Posts { get; private set; }
        public ITagRepository Tags { get; private set; }
        public ICommentRepository Comments { get; private set; }
        public IDonationRequestRepository DonationRequests { get; private set; }
        public IMoneyDonationRepository MoneyDonations { get; private set; }
        public IDonatedItemRepository DonatedItems { get; private set; }
        public IReportedItemRepository ReportedItems { get; private set; }
        public IAuctionRepository Auctions { get; private set; }

        public UnitOfWork(MainContext context)
        {
            _context = context;

            Contributors = new ContributorRepository(_context);
            Organizations = new OrganizationRepository(_context);
            Badges = new BadgeRepository(_context);
            Posts = new PostRepository(_context);
            Tags = new TagRepository(_context);
            Comments = new CommentRepository(_context);
            DonationRequests = new DonationRequestRepository(_context);
            MoneyDonations = new MoneyDonationRepository(_context);
            DonatedItems = new DonatedItemRepository(_context);
            ReportedItems = new ReportedItemRepository(_context);
            Auctions = new AuctionRepository(_context);
        }

        public int CompleteWork()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteWorkAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}