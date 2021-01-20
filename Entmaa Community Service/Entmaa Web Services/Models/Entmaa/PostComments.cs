using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class PostComments
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserID { get; set; }
        public string Comment { get; set; }
        public DateTime DateCommented { get; set; }
        public int ParentComment { get; set; }

        public User User { get; set; }
        public Post Post { get; set; }
        public ICollection<PostComments> Postcomments { get; set; }
    }
}