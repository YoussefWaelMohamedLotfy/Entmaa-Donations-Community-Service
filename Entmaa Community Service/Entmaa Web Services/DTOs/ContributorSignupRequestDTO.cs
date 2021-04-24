﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs
{
    public class ContributorSignupRequestDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
    }

    public class ContributorSignupResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}