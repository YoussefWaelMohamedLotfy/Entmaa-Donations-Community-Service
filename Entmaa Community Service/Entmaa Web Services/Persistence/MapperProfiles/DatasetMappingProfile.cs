using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Entmaa_Web_Services.DTOs.Dataset;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.MapperProfiles
{
    public class DatasetMappingProfile : Profile
    {
        public DatasetMappingProfile()
        {
            CreateMap<ContributorDatasetDTO, Contributor>();
            CreateMap<OrganizationDatasetDTO, Organization>();
            CreateMap<BadgeDatasetDTO, Badge>();
        }
    }
}