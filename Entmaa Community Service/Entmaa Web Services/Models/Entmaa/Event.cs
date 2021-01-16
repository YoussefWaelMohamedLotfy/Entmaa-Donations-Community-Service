using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Event
    {
        public int PostID { get; set; }

        public string Name { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public string MapLocation { get; set; }
        
        public string Address { get; set; }
        
        public int CityID { get; set; }
        
        public int InterestedCount { get; set; }
        
        public int NeededCount { get; set; }
        
        public int AcceptedCount { get; set; }

        public Post Post { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}