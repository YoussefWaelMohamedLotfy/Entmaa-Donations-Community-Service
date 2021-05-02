using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs.Donations;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Controllers.APIs
{
    public class MoneyDonationController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public MoneyDonationController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/Contributor/{id}/moneydonations")]
        [HttpGet]
        public IHttpActionResult GetContributorDonations(int id)
        {
            var donations = _unit.MoneyDonations.GetContributorDonations(id);

            if (donations == null)
                return NotFound();

            var dto = donations.Select(_mapper.Map<MoneyDonation, GetMoneyDonationDTO>);
            return Json(dto);
        }

        [Route("api/Organizations/{id}/moneydonations")]
        [HttpGet]
        public IHttpActionResult GetDonationsToOrganization(int id)
        {
            var donations = _unit.MoneyDonations.GetDonationsToOrganization(id);

            if (donations == null)
                return NotFound();

            var dto = donations.Select(_mapper.Map<MoneyDonation, GetMoneyDonationDTO>);
            return Json(dto);
        }

        [Route("api/Contributor/{id}/moneydonations")]
        [HttpPost]
        public IHttpActionResult DonateToOrganization(int id, MoneyDonationDTO donationDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var contributor = _unit.Contributors.Get(id);

            if (contributor == null)
                return NotFound();

            var donation = _mapper.Map<MoneyDonation>(donationDTO);
            _unit.MoneyDonations.Add(donation);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }



    }
}
