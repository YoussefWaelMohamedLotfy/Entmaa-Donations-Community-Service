using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class UserLocation
    {
        public int ID { get; set; }
        
        public int UserID { get; set; }
        
        public int CityID { get; set; }
        
        public string Address { get; set; }
        
        public string MapLocation { get; set; }
    }
}