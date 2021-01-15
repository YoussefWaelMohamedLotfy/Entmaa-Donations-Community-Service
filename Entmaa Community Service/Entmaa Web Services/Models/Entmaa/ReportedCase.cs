using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.Models.Entmaa
{
    public class ReportedCase
    {
        public int ID { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string Photo { get; set; }
        
        public int ReportedBy { get; set; }
        
        public int ReportedTo { get; set; }
    }
}