using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Organization : User
    {
        public Organization()
        {
            ContributorsFollowed = new HashSet<Contributor>();
            Posts = new HashSet<Post>();
            AuctionsCreated = new HashSet<Auction>();
            ReviewsGiven = new HashSet<Review>();
            OrganizationAlbumPhotos = new HashSet<OrganizationAlbumPhoto>();
            DonatedItems = new HashSet<DonatedItem>();
            CollectedItemDonations = new HashSet<DonatedItem>();
            Subscriptions = new HashSet<Subscription>();
            ReportedCases = new HashSet<ReportedCase>();
            MoneyDonationsReceived = new HashSet<MoneyDonation>();
        }

        public float Rating { get; set; }
        
        public bool IsApproved { get; set; }
        
        public DateTime FoundedDate { get; set; }
        
        public string FawryToken { get; set; }

        public ICollection<Contributor> ContributorsFollowed { get; set; }

        public ICollection<Post> Posts { get; set; }
        
        public ICollection<Auction> AuctionsCreated { get; set; }

        public ICollection<Review> ReviewsGiven { get; set; }

        public ICollection<OrganizationAlbumPhoto> OrganizationAlbumPhotos { get; set; }

        public ICollection<DonatedItem> DonatedItems { get; set; }

        public ICollection<DonatedItem> CollectedItemDonations { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }

        public ICollection<ReportedCase> ReportedCases { get; set; }

        public ICollection<MoneyDonation> MoneyDonationsReceived { get; set; }
    }
}