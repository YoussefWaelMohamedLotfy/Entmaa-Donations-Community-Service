using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Entmaa_Web_Services.DTOs.Subscriptions;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.MapperProfiles
{
    public class SubscriptionMappingProfile : Profile
    {
        public SubscriptionMappingProfile()
        {
            CreateMap<AddSubscriptionDTO, Subscription>();
            CreateMap<EditSubscriptionDTO, Subscription>();

            CreateMap<Subscription, GetSubscriptionsDTO>();
        }
    }
}