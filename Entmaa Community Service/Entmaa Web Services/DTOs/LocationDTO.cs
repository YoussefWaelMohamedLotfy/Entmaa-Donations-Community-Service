using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs
{
    public class LocationDTO
    {
        public CityDTO City { get; set; }

        public string Address { get; set; }
        
        public string MapsLocation { get; set; }
    }
}