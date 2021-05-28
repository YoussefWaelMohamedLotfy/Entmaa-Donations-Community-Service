using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Entmaa_Web_Services.DTOs.DonationRequests;
using Entmaa_Web_Services.DTOs.Donations;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.MapperProfiles
{
    public class DonationRequestMappingProfile : Profile
    {
        public DonationRequestMappingProfile()
        {
            CreateMap<CreateDonationRequestDTO, DonationRequest>();
            CreateMap<EditDonationRequestDTO, Post>();
            CreateMap<MoneyDonationOnRequestDTO, MoneyDonationOnRequest>();
            CreateMap<UserDTO, Contributor>();

            CreateMap<DonationRequest, GetDonationRequestsDTO>();
            CreateMap<Post, GetDonationRequestsDTO>();
            CreateMap<MoneyDonationOnRequest, GetMoneyDonationsOnRequestDTO>();

        }
    }
}