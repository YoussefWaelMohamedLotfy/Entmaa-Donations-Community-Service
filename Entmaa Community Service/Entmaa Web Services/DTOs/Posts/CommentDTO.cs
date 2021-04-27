using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Posts
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string CommentText { get; set; }

        public DateTime TimePosted { get; set; }

        public UserDTO CommentedBy { get; set; }
    }
}