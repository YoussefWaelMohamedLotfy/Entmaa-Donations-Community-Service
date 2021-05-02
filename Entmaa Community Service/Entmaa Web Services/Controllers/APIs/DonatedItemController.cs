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
    [AllowAnonymous]
    public class DonatedItemController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public DonatedItemController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/donateditems")]
        [HttpGet]
        public IHttpActionResult GetAllDonatedItems()
        {
            var items = _unit.DonatedItems.GetAllDonatedItems().ToList();

            if (items == null)
                return NotFound();

            var dto = items.Select(_mapper.Map<DonatedItem, GetDonatedItemsDTO>);
            return Json(dto);
        }

        [Route("api/Contributors/{id}/donateditems")]
        [HttpGet]
        public IHttpActionResult GetContributorDonatedItems(int id)
        {
            var items = _unit.DonatedItems.GetAllDonatedItems().Where(i => i.DonatedBy == id).ToList();

            if (items == null)
                return NotFound();

            var dto = items.Select(_mapper.Map<DonatedItem, GetDonatedItemsDTO>);
            return Json(dto);
        }

        [Route("api/Organizations/{id}/donateditems")]
        [HttpGet]
        public IHttpActionResult GetReceivedDonatedItems(int id)
        {
            var items = _unit.DonatedItems.GetAllDonatedItems().Where(i => i.IsDelivered == true && i.DonatedTo == id).ToList();

            if (items == null)
                return NotFound();

            var dto = items.Select(_mapper.Map<DonatedItem, GetDonatedItemsDTO>);
            return Json(dto);
        }

        [Route("api/Contributors/{id}/donateditems")]
        [HttpPost]
        public IHttpActionResult AddDonatedItem(int id, AddDonatedItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var contributor = _unit.Contributors.GetContributorProfile(id);

            if (contributor == null)
                return NotFound();

            var item = _mapper.Map<DonatedItem>(itemDTO);
            item.DonatedBy = contributor.ID;
            item.DonatedTo = 9;

            contributor.DonatedItems.Add(item);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

        [Route("api/Contributors/{id}/donateditems/{itemId}")]
        [HttpPatch]
        public IHttpActionResult EditDonatedItem(int id, int itemId, EditDonatedItemDTO itemDTO)
        {
            var contributor = _unit.Contributors.GetContributorProfile(id);
            var item = _unit.DonatedItems.Get(itemId);

            if (contributor == null || item == null)
                return NotFound();

            _mapper.Map(itemDTO, item);
            item.DonatedBy = id;

            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

        [Route("api/Contributors/{id}/donateditems/{itemId}")]
        [HttpDelete]
        public IHttpActionResult DeleteDonatedItem(int id, int itemId)
        {
            var contributor = _unit.Contributors.GetContributorProfile(id);
            var item = _unit.DonatedItems.Get(itemId);

            if (contributor == null || item == null)
                return NotFound();

            _unit.DonatedItems.Delete(item);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }
    }
}
