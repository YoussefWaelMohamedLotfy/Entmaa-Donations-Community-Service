using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs
{
    public class UserSignupRequestDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
    }

    public class UserSignupResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}