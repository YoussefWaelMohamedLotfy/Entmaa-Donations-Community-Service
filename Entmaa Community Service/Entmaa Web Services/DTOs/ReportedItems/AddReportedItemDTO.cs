using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.ReportedItems
{
    public class AddReportedItemDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string MapLocation { get; set; }

        public int CreatedBy { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }
    }
}