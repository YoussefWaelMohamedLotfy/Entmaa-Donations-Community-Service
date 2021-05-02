using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.DTOs.Donations
{
    public class GetMoneyDonationDTO
    {
        public int Id { get; set; }

        public UserDTO Contributor { get; set; }

        public UserDTO Organization { get; set; }

        public int MoneyAmount { get; set; }

        public string DonationToken { get; set; }
    }
}