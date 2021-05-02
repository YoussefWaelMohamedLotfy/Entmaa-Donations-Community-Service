using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Donations
{
    public class GetDonatedItemsDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }

        public ContributorDTO Contributor { get; set; }
    }
}