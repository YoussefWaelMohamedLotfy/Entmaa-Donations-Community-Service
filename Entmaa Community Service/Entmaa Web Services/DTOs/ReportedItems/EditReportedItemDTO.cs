using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.ReportedItems
{
    public class EditReportedItemDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string MapLocation { get; set; }

        public bool IsFound { get; set; }

        public int ResolvedBy { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }
    }
}