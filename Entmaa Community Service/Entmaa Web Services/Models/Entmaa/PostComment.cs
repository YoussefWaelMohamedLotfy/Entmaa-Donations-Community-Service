using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class PostComment
    {
        public int ID { get; set; }
        
        public int PostID { get; set; }
        
        public int UserID { get; set; }
        
        public string Comment { get; set; }
        
        public DateTime DateCommented { get; set; }
        
        public User User { get; set; }
        
        public Post Post { get; set; }
        
        public PostComment ParentComment { get; set; }
    }
}