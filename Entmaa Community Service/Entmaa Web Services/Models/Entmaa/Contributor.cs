using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Contributor : User
    {
        public Contributor()
        {
            OrganizationsFollowing = new HashSet<Organization>();
            EventsVolunteeredIn = new HashSet<Volunteer>();
            AuctionsJoined = new HashSet<AuctionBidder>();
            BadgesOwned = new HashSet<Badge>();
            MoneyDonationsOnRequest = new HashSet<MoneyDonationOnRequest>();
            DonatedItems = new HashSet<DonatedItem>();
            Subscriptions = new HashSet<Subscription>();
            ReviewsGiven = new HashSet<Review>();
            ReportedCases = new HashSet<ReportedCase>();
            MoneyDonationsMade = new HashSet<MoneyDonation>();
            ReportedItemsCreated = new HashSet<ReportedItem>();
            ReportedItemsResolved = new HashSet<ReportedItem>();
        }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public ICollection<Organization> OrganizationsFollowing { get; set; }

        public ICollection<Volunteer> EventsVolunteeredIn { get; set; }

        public ICollection<AuctionBidder> AuctionsJoined { get; set; }

        public ICollection<Badge> BadgesOwned { get; set; }

        public ICollection<MoneyDonationOnRequest> MoneyDonationsOnRequest { get; set; }

        public ICollection<DonatedItem> DonatedItems { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }

        public ICollection<Review> ReviewsGiven { get; set; }

        public ICollection<ReportedCase> ReportedCases { get; set; }

        public ICollection<MoneyDonation> MoneyDonationsMade { get; set; }

        public ICollection<ReportedItem> ReportedItemsCreated { get; set; }

        public ICollection<ReportedItem> ReportedItemsResolved { get; set; }
    }
}