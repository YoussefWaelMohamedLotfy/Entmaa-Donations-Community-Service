using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.DTOs.Donations;

namespace Entmaa_Web_Services.DTOs.ReportedCases
{
    public class GetReportedCasesDTO
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public UserDTO Contributor { get; set; }
    }
}