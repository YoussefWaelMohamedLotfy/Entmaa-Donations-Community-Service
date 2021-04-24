using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs
{
    public class ContributorLoginRequestDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class ContributorLoginResponseDTO
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
    }
}