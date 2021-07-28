using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs.Events;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Controllers.APIs
{
    [AllowAnonymous]
    public class EventController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public EventController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/Organizations/{id}/events")]
        [HttpPost]
        public IHttpActionResult CreateEvent(int id, CreateEventDTO eventDTO)
        {
            var organization = _unit.Organizations.Get(id);

            if (organization == null)
                return NotFound();

            var post = new Post()
            {
                Title = eventDTO.Title,
                Description = eventDTO.Description,
            };

            _unit.Posts.Add(post);
            _unit.CompleteWork();

            var orgEvent = _mapper.Map<Event>(eventDTO);
            _unit.Events.Add(orgEvent);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

        [Route("api/Organizations/{id}/events/{eventId}")]
        [HttpPatch]
        public IHttpActionResult EditEvent(int id, int eventId, CreateEventDTO eventDTO)
        {
            var org = _unit.Organizations.Get(id);
            var post = _unit.Posts.Get(eventId);
            var orgEvent = _unit.Events.Get(eventId);

            if (org == null || post == null)
                return NotFound();

            post.Title = eventDTO.Title;
            post.Description = eventDTO.Description;

            _mapper.Map(eventDTO, orgEvent);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

        [Route("api/Organizations/{id}/events/{eventId}")]
        [HttpDelete]
        public IHttpActionResult DeleteEvent(int id, int eventId)
        {
            var org = _unit.Organizations.Get(id);
            var post = _unit.Posts.Get(eventId);
            var orgEvent = _unit.Events.Get(eventId);

            if (org == null || post == null)
                return NotFound();

            _unit.Events.Delete(orgEvent);
            _unit.Posts.Delete(post);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }
    }
}