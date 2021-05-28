using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs.DonationRequests;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Controllers.APIs
{
    public class DonationRequestController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public DonationRequestController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/Organizations/{id}/donationrequests")]
        [HttpGet]
        public IHttpActionResult GetOrganizationDonationRequests(int id)
        {
            var requests = _unit.DonationRequests.GetOrganizationDonationRequests(id);

            var posts = requests.Select(r => r.Post).ToList();


            if (requests == null)
                return NotFound();

            var dto = posts.Select(_mapper.Map<Post, GetDonationRequestsDTO>);
            return Json(dto);
        }

        [Route("api/Organizations/{id}/donationrequests")]
        [HttpPost]
        public IHttpActionResult CreateDonationRequestPost(int id, CreateDonationRequestDTO requestDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var organization = _unit.Organizations.Get(id);

            if (organization == null)
                return NotFound();

            var post = new Post()
            {
                TimePosted = DateTime.Now,
                Title = requestDTO.Title,
                Description = requestDTO.Description,
                PostedBy = id,
                PostTypeID = 1,
            };
            _unit.Posts.Add(post);
            _unit.CompleteWork();

            var donationRequest = _mapper.Map<DonationRequest>(requestDTO);
            donationRequest.PostID = post.ID;
            donationRequest.DonationTypeID = 1;
            _unit.DonationRequests.Add(donationRequest);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

        [Route("api/Organizations/{id}/donationrequests/{requestId}")]
        [HttpPatch]
        public IHttpActionResult EditDonationRequestPost(int id, int requestId, EditDonationRequestDTO requestDTO)
        {
            var organization = _unit.Organizations.Get(id);
            var post = _unit.Posts.Get(requestId);

            if (organization == null || post == null)
                return NotFound();

            _mapper.Map(requestDTO, post);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

        [Route("api/Organizations/{id}/donationrequests/{requestId}")]
        [HttpDelete]
        public IHttpActionResult DeleteDonationRequestPost(int id, int requestId)
        {
            var organization = _unit.Organizations.Get(id);
            var donationRequest = _unit.DonationRequests.Get(requestId);

            if (organization == null || donationRequest == null)
                return NotFound();

            var post = _unit.Posts.Get(requestId);
            _unit.DonationRequests.Delete(donationRequest);
            _unit.Posts.Delete(post);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

        [Route("api/DonationRequests/{requestId}/moneydonations")]
        [HttpGet]
        public IHttpActionResult GetMoneyDonationsOnRequest(int requestId)
        {
            var donations = _unit.DonationRequests.GetMoneyDonationsOnRequest(requestId);

            if (donations == null)
                return NotFound();

            var dto = donations.Select(_mapper.Map<MoneyDonationOnRequest, GetMoneyDonationsOnRequestDTO>);
            return Json(dto);
        }

        [Route("api/DonationRequests/{requestId}/moneydonations")]
        [HttpPost]
        public IHttpActionResult DonateMoneyOnRequest(int requestId, MoneyDonationOnRequestDTO donationDTO)
        {
            var request = _unit.DonationRequests.GetDonationRequest(requestId);

            if (request == null)
                return NotFound();

            var moneyDonation = _mapper.Map<MoneyDonationOnRequest>(donationDTO);
            request.MoneyDonationsOnRequest.Add(moneyDonation);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }
    }
}
