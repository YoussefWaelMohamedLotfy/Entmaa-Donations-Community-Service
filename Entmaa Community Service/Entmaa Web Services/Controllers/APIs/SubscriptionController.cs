using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Entmaa_Web_Services.Core;
using Entmaa_Web_Services.DTOs.Subscriptions;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Controllers.APIs
{
    [AllowAnonymous]
    public class SubscriptionController : ApiController
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SubscriptionController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [Route("api/Contributors/{id}/subscriptions")]
        [HttpGet]
        public IHttpActionResult GetContributorSubscriptions(int id)
        {
            var contributorSubscriptions = _unit.Subscriptions.GetContributorSubscriptions(id);

            if (contributorSubscriptions == null)
                return NotFound();

            var dto = contributorSubscriptions.Select(_mapper.Map<Subscription, GetSubscriptionsDTO>);
            return Json(dto);
        }

        [Route("api/Contributors/{id}/subscriptions")]
        [HttpPost]
        public IHttpActionResult AddNewSubscription(int id, AddSubscriptionDTO subscriptionDTO)
        {
            var contributor = _unit.Contributors.Get(id);

            if (contributor == null)
                return NotFound();

            var subscription = _mapper.Map<Subscription>(subscriptionDTO);
            subscription.SubscribedBy = id;
            subscription.RenewalDate = new DateTime(2000, 4, 11);
            subscription.EndDate = new DateTime(2000, 4, 11);

            _unit.Subscriptions.Add(subscription);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

        [Route("api/Contributors/{id}/subscriptions/{subId}")]
        [HttpPatch]
        public IHttpActionResult EditSubscription(int id, int subId, EditSubscriptionDTO subscriptionDTO)
        {
            var contributor = _unit.Contributors.Get(id);
            var subscription = _unit.Subscriptions.Get(subId);

            if (contributor == null || subscription == null)
                return NotFound();

             _mapper.Map<Subscription>(subscriptionDTO);
            subscription.EndDate = new DateTime(2000, 4, 19);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }

        [Route("api/Contributors/{id}/subscriptions/{subId}")]
        [HttpDelete]
        public IHttpActionResult DeleteSubscription(int id, int subId)
        {
            var contributor = _unit.Contributors.Get(id);
            var subscription = _unit.Subscriptions.Get(subId);

            if (contributor == null || subscription == null)
                return NotFound();

            _unit.Subscriptions.Delete(subscription);
            _unit.CompleteWork();

            return Json(new { message = "Success" });
        }
    }
}
