using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Volunteer
    {
        public int EventID { get; set; }
        
        public int ContributorID { get; set; }

        public bool IsAccepted { get; set; }

        public Event Event { get; set; }

        public Contributor Contributor { get; set; }
    }
}