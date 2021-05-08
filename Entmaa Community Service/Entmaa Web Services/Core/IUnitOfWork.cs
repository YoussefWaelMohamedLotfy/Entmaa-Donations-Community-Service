using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entmaa_Web_Services.Core.Repositories;

namespace Entmaa_Web_Services.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IContributorRepository Contributors { get; }
        IOrganizationRepository Organizations { get; }
        IBadgeRepository Badges { get; }
        IPostRepository Posts { get; }
        ITagRepository Tags { get; }
        ICommentRepository Comments { get; }
        IDonationRequestRepository DonationRequests { get; }
        IMoneyDonationRepository MoneyDonations { get; }
        IDonatedItemRepository DonatedItems { get; }
        IReportedItemRepository ReportedItems { get; }
        IAuctionRepository Auctions { get; }
        IAuctionBidderRepository AuctionBidders { get; }
        ISubscriptionRepository Subscriptions { get; }
        INotificationRepository Notifications { get; }

        int CompleteWork();
        Task<int> CompleteWorkAsync();
    }
}
