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
using Entmaa_Web_Services.Persistence;
using Entmaa_Web_Services.Persistence.MapperProfiles;

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

            return Json(dto);
        }

        [HttpPost]
        public IHttpActionResult CreateContributor([FromBody]Contributor contributor)
        {




            return Created(new Uri(Request.RequestUri + "/" + contributor.ID), contributor);
        }
    }
}
