using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Entmaa_Web_Services.DTOs.ReportedItems;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.MapperProfiles
{
    public class ReportedItemMappingProfile : Profile
    {
        public ReportedItemMappingProfile()
        {
            CreateMap<AddReportedItemDTO, ReportedItem>();
            CreateMap<EditReportedItemDTO, ReportedItem>();

            CreateMap<ReportedItem, GetReportedItemsDTO>();
        }
    }
}