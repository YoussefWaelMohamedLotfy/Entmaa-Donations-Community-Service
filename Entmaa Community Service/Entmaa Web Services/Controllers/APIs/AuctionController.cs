using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs.Auctions;
using Entmaa_Web_Services.DTOs.Donations;
using Entmaa_Web_Services.Models.Entmaa;
using Newtonsoft.Json;

namespace Entmaa_Web_Services.Controllers.APIs
{
    [AllowAnonymous]
    public class AuctionController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public AuctionController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/auctions")]
        [HttpGet]
        public IHttpActionResult GetAllAuctions()
        {
            var auctions = _unit.Auctions.GetAllAuctions();

            if (auctions == null)
                return NotFound();

            var dto = auctions.Select(_mapper.Map<Auction, GetAuctionsDTO>);
            return Json(dto, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        [Route("api/Organizations/{id}/auctions")]
        [HttpGet]
        public IHttpActionResult GetOrganizationAuctions(int id)
        {
            var auctions = _unit.Auctions.GetOrganizationAuctions(id);

            if (auctions == null)
                return NotFound();

            var dto = auctions.Select(_mapper.Map<Auction, GetAuctionsDTO>);
            return Json(dto);
        }

        [Route("api/Contributors/{id}/auctions")]
        [HttpGet]
        public IHttpActionResult GetContributorBiddedAuctions(int id)
        {
            var auctions = _unit.Auctions.GetContributorBiddedAuctions(id);

            if (auctions == null)
                return NotFound();

            var dto = auctions.Select(_mapper.Map<Auction, GetAuctionsDTO>);
            return Json(dto);
        }

        [Route("api/Organizations/{id}/auctions")]
        [HttpGet]
        public IHttpActionResult GetAuctionWinner(int id)
        {
            var auctions = _unit.Auctions.GetAuctionWinner(id);

            if (auctions == null)
                return NotFound();

            //var dto = auctions.Select(_mapper.Map<Auction, UserDTO>);
            return Ok();
        }

        [Route("api/Organizations/{id}/auctions")]
        [HttpPost]
        public IHttpActionResult CreateNewAuction(int id, CreateAuctionDTO auctionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var auction = _mapper.Map<Auction>(auctionDTO);
            auction.HostedBy = id;
            auction.EndDate = new DateTime(2000, 1, 1);

            _unit.Auctions.Add(auction);
            _unit.CompleteWork();

            return Json(new { id = auction.ID });
        }

        [Route("api/Organizations/{id}/auctions/{auctionId}")]
        [HttpPatch]
        public IHttpActionResult EditAuction(int id, int auctionId, EditAuctionDTO auctionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var auction = _unit.Auctions.GetAuction(auctionId);

            if (auction == null)
                return NotFound();

            _mapper.Map<Auction>(auctionDTO);
            auction.HostedBy = id;

            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

        [Route("api/Organizations/{id}/auctions/{auctionId}")]
        [HttpDelete]
        public IHttpActionResult DeleteAuction(int id, int auctionId)
        {
            var organization = _unit.Organizations.GetOrganization(id);
            var auction = _unit.Auctions.GetAuction(auctionId);

            if (organization == null || auction == null)
                return NotFound();

            _unit.Auctions.Delete(auction);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }
    }
}
