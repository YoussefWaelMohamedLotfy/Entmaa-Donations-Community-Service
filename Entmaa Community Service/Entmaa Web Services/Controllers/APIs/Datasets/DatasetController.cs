using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs.Dataset;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Controllers.APIs.Datasets
{
    [AllowAnonymous]
    public class DatasetController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public DatasetController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/Dataset/Contributor")]
        [HttpPost]
        public IHttpActionResult CreateContributor(ContributorDatasetDTO contributorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid.");

            var contributor = _mapper.Map<Contributor>(contributorDTO);

            _unit.Contributors.Add(contributor);
            _unit.CompleteWork();

            contributorDTO.ID = contributor.ID;
            return Created(new Uri(Request.RequestUri + "/" + contributor.ID), contributorDTO);
        }

        [Route("api/Dataset/Organization")]
        [HttpPost]
        public IHttpActionResult CreateOrganization(OrganizationDatasetDTO organizationDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid.");

            var organization = _mapper.Map<Organization>(organizationDTO);

            _unit.Organizations.Add(organization);
            _unit.CompleteWork();

            organizationDTO.ID = organization.ID;
            return Created(new Uri(Request.RequestUri + "/" + organization.ID), organizationDTO);
        }

        [Route("api/Dataset/Badge")]
        [HttpPost]
        public IHttpActionResult CreateBadge(BadgeDatasetDTO badgeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid.");

            var badge = _mapper.Map<Badge>(badgeDTO);

            _unit.Badges.Add(badge);
            _unit.CompleteWork();

            badgeDTO.ID = badge.ID;
            return Created(new Uri(Request.RequestUri + "/" + badge.ID), badgeDTO);
        }

        [Route("api/Dataset/Post")]
        [HttpPost]
        public IHttpActionResult CreatePost(PostDatasetDTO postDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid.");

            var post = _mapper.Map<Post>(postDTO);

            _unit.Posts.Add(post);
            _unit.CompleteWork();

            postDTO.ID = post.ID;
            return Created(new Uri(Request.RequestUri + "/" + post.ID), postDTO);
        }
    }
}
