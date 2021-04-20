using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Dataset
{
    public class OrganizationDatasetDTO
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateJoined { get; set; }

        public string FirebaseToken { get; set; }

        public byte UserTypeID { get; set; }

        public bool IsApproved { get; set; }

        public DateTime FoundedDate { get; set; }

        public string FawryToken { get; set; }
    }
}