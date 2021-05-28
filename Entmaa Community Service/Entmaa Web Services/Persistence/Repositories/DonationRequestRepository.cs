using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Core.Repositories;
using Entmaa_Web_Services.DTOs.DonationRequests;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.Repositories
{
    public class DonationRequestRepository : Repository<DonationRequest>, IDonationRequestRepository
    {
        public MainContext MainContext { get { return _context as MainContext; } }

        public DonationRequestRepository(DbContext context) : base(context)
        {
        }

        public DonationRequest GetDonationRequest(int id)
        {
            return MainContext.DonationRequests
                .Include(r => r.Post)
                .Include(r => r.MoneyDonationsOnRequest)
                .SingleOrDefault(r => r.PostID == id);
        }

        public IEnumerable<MoneyDonationOnRequest> GetMoneyDonationsOnRequest(int id)
        {
            return MainContext.MoneyDonationsOnRequest
                .Include(d => d.Contributor)
                .Where(d => d.RequestID == id)
                .ToList();
        }

        public IEnumerable<DonationRequest> GetOrganizationDonationRequests(int id)
        {
            var requests = MainContext.DonationRequests
                .Include(p => p.Post)
                .Where(p => p.Post.PostedBy == id)
                //.OrderBy(p => p.PostID)
                .ToList();

            //var posts = MainContext.Posts
            //    .Include(p => p.Organization)
            //    .Include(p => p.UsersReacted)
            //    .Include(p => p.Tags)
            //    .Where(p => p.PostedBy == id)
            //    .OrderBy(p => p.ID)
            //    .ToList();

            //var dto = new List<GetDonationRequestsDTO>();

            //foreach (var item in posts)
            //{
            //    var obj = new GetDonationRequestsDTO()
            //    {
            //        ID = item.ID,
            //        Title = item.Title,
            //        Description = item.Description,
            //        TimePosted = item.TimePosted,
            //        Tags = (IEnumerable<DTOs.TagDTO>)item.Tags,
            //        Organization = new DTOs.OrganizationInfoDTO()
            //        {
            //            id = item.Organization.ID,
            //            Name = item.Organization.Name,
            //            FawryToken = item.Organization.FawryToken,
            //            ProfilePhotoUrl = item.Organization.ProfilePhotoUrl
            //        },
            //        PostComments =
            //    };
            //}

            return requests;
        }

        public IEnumerable<Post> GetPosts(int id)
        {
            return MainContext.Posts
                .Include(p => p.Organization)
                .Include(p => p.PostComments)
                .Include(p => p.UsersReacted)
                .Include(p => p.Tags)
                .Include(p => p.DonationRequest)
                .Where(p => p.PostedBy == id && p.DonationRequest != null)
                .ToList();
        }
    }
}