using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Entmaa_Web_Services.DTOs.Donations;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.MapperProfiles
{
    public class DonationMappingProfile : Profile
    {
        public DonationMappingProfile()
        {
            CreateMap<AddDonatedItemDTO, DonatedItem>();
            CreateMap<EditDonatedItemDTO, DonatedItem>();

            CreateMap<DonatedItem, GetDonatedItemsDTO>();
            CreateMap<Contributor, ContributorDTO>();

        }
    }
}