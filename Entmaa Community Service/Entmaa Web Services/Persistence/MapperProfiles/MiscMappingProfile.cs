using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Entmaa_Web_Services.DTOs.Misc;
using Entmaa_Web_Services.DTOs.ReportedCases;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.MapperProfiles
{
    public class MiscMappingProfile : Profile
    {
        public MiscMappingProfile()
        {
            CreateMap<AddReportedCaseDTO, ReportedCase>();

            CreateMap<Notification, GetNotificationsDTO>();
            CreateMap<ReportedCase, GetReportedCasesDTO>();
        }
    }
}