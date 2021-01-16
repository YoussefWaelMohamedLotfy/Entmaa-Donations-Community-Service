using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class City
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int CountryID { get; set; }

        public Country Country { get; set; }
    }

    public class Country
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}