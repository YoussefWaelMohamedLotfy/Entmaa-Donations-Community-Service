using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.ReportedCases
{
    public class AddReportedCaseDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int ReportedTo { get; set; }

        public string Photo { get; set; }
    }
}