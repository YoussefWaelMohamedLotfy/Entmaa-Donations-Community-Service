using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs
{
    public class OrganizationInfoDTO
    {
        public int id { get; set; }

        public string Name { get; set; }
        
        public string ProfilePhotoUrl { get; set; }

        public string FawryToken { get; set; }
    }
}