using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Controllers.APIs
{
    [AllowAnonymous]
    public class ContributorController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ContributorController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/Contributor/{id}/profile")]
        [HttpGet]
        public IHttpActionResult GetProfile(int id)
        {
            var userProfile = _unit.Contributors.GetContributorProfile(id);

            if (userProfile == null)
                return NotFound();

            var dto = _mapper.Map<GetContributorProfileDTO>(userProfile);
            dto.PhoneNumber = userProfile.PhoneNumbers.FirstOrDefault().PhoneNumber;

            return Json(dto);
        }

        [Route("api/Contributor/{id}/badges")]
        [HttpGet]
        public IHttpActionResult GetBadges(int id)
        {
            var userProfile = _unit.Contributors.GetContributorBadges(id);

            if (userProfile == null)
                return NotFound();

            var dto = _mapper.Map<GetContributorProfileDTO>(userProfile);
            dto.PhoneNumber = userProfile.PhoneNumbers.FirstOrDefault().PhoneNumber;

            return Json(dto);
        }

        [Route("api/Contributor/{id}/profile")]
        [HttpPost]
        public IHttpActionResult CreateContributor(CreateContributorProfileDTO contributorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var contributor = _mapper.Map<Contributor>(contributorDTO);

            _unit.Contributors.Add(contributor);
            _unit.CompleteWork();

            return Json(new { message = "Success"});
        }
    }
}
