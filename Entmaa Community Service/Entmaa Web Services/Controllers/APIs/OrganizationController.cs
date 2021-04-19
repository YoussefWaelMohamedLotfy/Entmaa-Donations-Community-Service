using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs;
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


    }
}
