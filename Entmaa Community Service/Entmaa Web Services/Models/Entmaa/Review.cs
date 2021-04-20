using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Review
    {
        public int ContributorID { get; set; }

        public int OrganizationID { get; set; }

        public float Rating { get; set; }

        public string ReviewComment { get; set; }

        public Contributor Contributor { get; set; }

        public Organization Organization { get; set; }
    }
}