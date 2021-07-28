using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Events
{
    public class CreateEventDTO
    {
        public DateTime TimePosted { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public LocationDTO Location { get; set; }

        public int NeededCount { get; set; }
    }
}