using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs
{
    public class GetOrganizationProfileDTO
    {
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileUrl { get; set; }
        public string  CoverPhotoUrl { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; }
        public LocationDTO Location { get; set; }
        public string FawryToken { get; set; }
        public DateTime DateFounded { get; set; }
        public int FollowersCount { get; set; }
        public int EventsCount { get; set; }
        public int DonationRequestCount  { get; set; }
        public int NewsPostsCount { get; set; }
        public float Rating { get; set; }
        public IEnumerable<string> AlbumPhotoUrls { get; set; }

    }
}