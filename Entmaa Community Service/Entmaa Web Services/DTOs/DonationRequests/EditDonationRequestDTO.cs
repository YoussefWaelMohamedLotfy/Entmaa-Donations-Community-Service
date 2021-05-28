using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.DonationRequests
{
    public class EditDonationRequestDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }
    }
}