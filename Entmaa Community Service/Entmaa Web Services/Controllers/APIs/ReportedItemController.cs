using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs.ReportedItems;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Controllers.APIs
{
    [AllowAnonymous]
    public class ReportedItemController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ReportedItemController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/reporteditems")]
        [HttpGet]
        public IHttpActionResult GetAllReportedItems()
        {
            var items = _unit.ReportedItems.GetAllReportedItems();

            if (items == null)
                return NotFound();

            var dto = items.Select(_mapper.Map<ReportedItem, GetReportedItemsDTO>);
            return Json(dto);
        }

        [Route("api/Contributor/{id}/reporteditems")]
        [HttpGet]
        public IHttpActionResult GetAllReportedItems(int id)
        {
            var items = _unit.ReportedItems.GetContributorReportedItems(id);

            if (items == null)
                return NotFound();

            var dto = items.Select(_mapper.Map<ReportedItem, GetReportedItemsDTO>);
            return Json(dto);
        }

        [Route("api/reporteditems")]
        [HttpPost]
        public IHttpActionResult AddReportedItem(AddReportedItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var item = _mapper.Map<ReportedItem>(itemDTO);
            item.ResolvedBy = 4;

            _unit.ReportedItems.Add(item);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

        [Route("api/reporteditems/{itemId}")]
        [HttpPatch]
        public IHttpActionResult EditReportedItem(int itemId, EditReportedItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Failed. Model not valid.");

            var reportedItem = _unit.ReportedItems.GetReportedItem(itemId);

            if (reportedItem == null)
                return NotFound();

            _mapper.Map(itemDTO, reportedItem);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

        [Route("api/reporteditems/{itemId}")]
        [HttpDelete]
        public IHttpActionResult DeleteReportedItem(int itemId)
        {
            var reportedItem = _unit.ReportedItems.Get(itemId);

            if (reportedItem == null)
                return NotFound();

            _unit.ReportedItems.Delete(reportedItem);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

    }
}