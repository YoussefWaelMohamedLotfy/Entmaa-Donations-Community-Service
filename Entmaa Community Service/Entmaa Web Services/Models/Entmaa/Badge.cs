using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class Badge
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Contributor> Contributors { get; set; }
    }
 }