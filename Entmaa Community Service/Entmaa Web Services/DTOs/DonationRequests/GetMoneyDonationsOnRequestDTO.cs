using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entmaa_Web_Services.DTOs.Donations;

namespace Entmaa_Web_Services.DTOs.DonationRequests
{
    public class GetMoneyDonationsOnRequestDTO
    {
        public int Id { get; set; }

        public UserDTO Contributor { get; set; }

        public int MoneyAmount { get; set; }

        public string DonationToken { get; set; }
    }
}