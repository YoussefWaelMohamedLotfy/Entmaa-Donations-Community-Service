using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Contributor : User
    {
        public int UserID { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public User User { get; set; }
    }
}