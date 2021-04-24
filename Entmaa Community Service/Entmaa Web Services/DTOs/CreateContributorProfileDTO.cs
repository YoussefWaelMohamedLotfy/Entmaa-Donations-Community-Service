using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs
{
    public class CreateContributorProfileDTO
    {
        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }

        public LocationDTO Location { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string FirebaseToken { get; set; }
    }
}