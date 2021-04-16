using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs
{
    public class CityDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CountryDTO Country { get; set; }
    }
}