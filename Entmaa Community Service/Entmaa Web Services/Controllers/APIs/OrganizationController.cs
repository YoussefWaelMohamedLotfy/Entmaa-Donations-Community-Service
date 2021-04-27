using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs;
using Entmaa_Web_Services.Models.Entmaa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Entmaa_Web_Services.Controllers.APIs
{
    [AllowAnonymous]
    public class OrganizationController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public OrganizationController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        
        [Route("api/Organization/{id}/profile")]
        [HttpGet]
        public IHttpActionResult GetProfile(int id)
        {
            var OrganizationProfile = _unit.Organizations.GetOrganization(id);

            if (OrganizationProfile == null)
                return NotFound();

            var dto = _mapper.Map<GetOrganizationProfileDTO>(OrganizationProfile);

            return Json(dto);
        }
        [Route("api/Organizations")]
        [HttpGet]
        public IHttpActionResult GetOrganizations()
        {
            var Organizations = _unit.Organizations.GetAllOrganizations();
            if (Organizations == null)
                return NotFound();

            var dto = Organizations.Select(_mapper.Map < Organization, OrganizationInfoDTO>);
            return Json(dto);
        }

        [Route("api/Organization/{id}/profile")]
        [HttpPatch]
        public IHttpActionResult OrganizationProfileEdit(int id,GetOrganizationProfileDTO organization)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid.");

            var OrganizationInDB = _unit.Organizations.ModifyOrganization(id);
            _mapper.Map(organization,OrganizationInDB);
            _unit.CompleteWork();
            return Json(new { message="Success"});


        }
        [Route("api/Organizations/sessions")]
        [HttpPost]

        public IHttpActionResult Login(UserLoginRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var organization= _unit.Organizations.Login(request.Email, request.Password);

            if (organization == null)
                return Unauthorized();

            var response = _mapper.Map<UserLoginResponseDTO>(organization);
            return Ok(response);

        }

        [Route("api/Organizations")]
        [HttpPost]
        public IHttpActionResult Signup(UserSignupRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var newOrganization = _mapper.Map<Organization>(request);
            newOrganization.IsApproved = true;
            newOrganization.FirebaseToken = "";
            newOrganization.FawryToken = "new token";
            newOrganization.DateJoined = DateTime.Now;
            newOrganization.FoundedDate = new DateTime(2007, 2, 13);


            _unit.Organizations.Add(newOrganization);
            _unit.CompleteWork();

            var responseDTO = _mapper.Map<UserSignupResponseDTO>(newOrganization); 
            return Json(responseDTO);
        }

        [Route("api/organization/{id}/profile")]
        public IHttpActionResult CreateOrganizationProfile(int id,CreateOrganizationProfileDTO OrganizationDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");
            var Organization = _unit.Organizations.GetOrganization(id);
            var TagsInDB=_unit.Tags.GetTags((List<TagDTO>)OrganizationDTO.Tags);
            foreach (var tag in TagsInDB)
            {
                ((HashSet<Tag>)Organization.Tags).Add(tag);


            }
            _mapper.Map(OrganizationDTO, Organization);
            _unit.CompleteWork();

            return Json(new { message = "Success" });

        }

    }

    
   
}
