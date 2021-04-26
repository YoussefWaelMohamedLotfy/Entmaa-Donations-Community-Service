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
            var userBadges = _unit.Contributors.GetContributorBadges(id).BadgesOwned;

            if (userBadges == null)
                return NotFound();

            var dto = userBadges.Select(_mapper.Map<Badge, ContributorBadgesDTO>);
            return Json(dto);
        }

        [Route("api/Contributors")]
        [HttpPost]
        public IHttpActionResult Signup(UserSignupRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var newContributor = _mapper.Map<Contributor>(request);
            newContributor.Gender = "";
            newContributor.FirebaseToken = "";
            newContributor.DateJoined = DateTime.Now;
            newContributor.BirthDate = new DateTime(2007, 2, 13);

            _unit.Contributors.Add(newContributor);
            _unit.CompleteWork();

            var responseDTO = _mapper.Map<ContributorSignupResponseDTO>(newContributor);
            return Json(responseDTO);
        }

        [Route("api/Contributors/sessions")]
        [HttpPost]
        public IHttpActionResult Login(UserLoginRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var contributor = _unit.Contributors.Login(request.Email, request.Password);

            if (contributor == null)
                return Unauthorized();

            var response = _mapper.Map<ContributorLoginResponseDTO>(contributor);
            return Ok(response);

        }

        [Route("api/Contributor/{id}/profile")]
        [HttpPost]
        public IHttpActionResult CreateContributor(int id, CreateContributorProfileDTO contributorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var contributor = _unit.Contributors.GetContributorProfileCreation(id);

            if (contributor == null)
                return NotFound();

            var tagsinDb = _unit.Tags.GetTags((List<TagDTO>)contributorDTO.Tags);
            
            foreach (var tag in tagsinDb)
            {
                ((HashSet<Tag>)contributor.Tags).Add(tag);
            }

            _mapper.Map(contributorDTO, contributor);
            _unit.CompleteWork();

            return Json(new { message = "Success"});
        }

        [Route("api/Contributor/{id}/profile")]
        [HttpPatch]
        public IHttpActionResult EditContributor(int id, CreateContributorProfileDTO contributorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var contributor = _unit.Contributors.GetContributorProfileCreation(id);

            if (contributor == null)
                return NotFound();

            var tagsinDb = _unit.Tags.GetTags((List<TagDTO>)contributorDTO.Tags);

            foreach (var tag in tagsinDb)
            {
                ((HashSet<Tag>)contributor.Tags).Add(tag);
            }

            _mapper.Map(contributorDTO, contributor);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }
    }
}
