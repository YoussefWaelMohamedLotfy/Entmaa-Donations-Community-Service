using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Dataset
{
    public class ContributorDatasetDTO
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateJoined { get; set; }

        public string FirebaseToken { get; set; }

        public byte UserTypeID { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }
    }
}