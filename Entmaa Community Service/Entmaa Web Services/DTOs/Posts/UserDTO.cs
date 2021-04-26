using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entmaa_Web_Services.DTOs.Posts
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte UserTypeId { get; set; }
    }
}