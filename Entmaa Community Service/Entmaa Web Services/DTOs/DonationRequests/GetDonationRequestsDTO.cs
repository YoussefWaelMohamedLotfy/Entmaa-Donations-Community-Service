using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.DTOs.Posts;

namespace Entmaa_Web_Services.DTOs.DonationRequests
{
    public class GetDonationRequestsDTO
    {
        public int ID { get; set; }

        public string Title { get; set; }
        
        public DateTime TimePosted { get; set; }

        public string Description { get; set; }

        public string PostPhotoUrl { get; set; }

        public OrganizationInfoDTO Organization { get; set; }

        public int ReactCount { get; set; }

        public IEnumerable<CommentDTO> PostComments { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }

        public int MoneyNeededAmount { get; set; }

        public bool ItemsAccepted { get; set; }
    }
}