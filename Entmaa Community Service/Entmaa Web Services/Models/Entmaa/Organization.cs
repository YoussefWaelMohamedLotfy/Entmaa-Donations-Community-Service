using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Organization : User
    {
        public int UserID { get; set; }
        
        public float Rating { get; set; }
        
        public bool IsApproved { get; set; }
        
        public DateTime FoundedDate { get; set; }
        
        public string FawryToken { get; set; }

        public User User { get; set; }
    }
}