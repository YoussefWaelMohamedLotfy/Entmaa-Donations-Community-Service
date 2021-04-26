﻿using AutoMapper;
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
    }
}
