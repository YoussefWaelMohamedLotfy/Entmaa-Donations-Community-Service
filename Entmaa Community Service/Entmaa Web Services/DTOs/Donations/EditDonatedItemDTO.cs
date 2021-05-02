using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Donations
{
    public class EditDonatedItemDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int DonatedBy { get; set; }

        public int DonatedTo { get; set; }

        public bool IsDelivered { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }

    }
}