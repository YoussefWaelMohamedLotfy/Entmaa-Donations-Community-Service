using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs.Misc;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Controllers.APIs
{
    [AllowAnonymous]
    public class NotificationController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public NotificationController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/Users/{id}/notifications")]
        [HttpGet]
        public IHttpActionResult GetUserNotifications(int id)
        {
            var notifications = _unit.Notifications.GetUserNotifications(id);

            if (notifications == null)
                return NotFound();

            var dto = notifications.Select(_mapper.Map<Notification, GetNotificationsDTO>);
            return Json(dto);
        }
    }
}
