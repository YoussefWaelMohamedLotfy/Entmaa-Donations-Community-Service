using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Posts
{
    public class GetOrganizationNewsDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime TimePosted { get; set; }

        public UserDTO Organization { get; set; }

        public IEnumerable<CommentDTO> PostComments { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }

        public int ReactCount { get; set; }
    }
}