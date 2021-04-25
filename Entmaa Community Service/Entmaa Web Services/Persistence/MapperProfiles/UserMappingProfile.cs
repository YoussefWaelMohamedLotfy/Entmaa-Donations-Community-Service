using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Entmaa_Web_Services.DTOs;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.MapperProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Contributor, GetContributorProfileDTO>();
            CreateMap<Badge, ContributorBadgesDTO>();
            CreateMap<UserLocation, LocationDTO>();
            CreateMap<City, CityDTO>();
            CreateMap<Country, CountryDTO>();

            CreateMap<LocationDTO, UserLocation>();
            CreateMap<CityDTO, City>();
            CreateMap<CountryDTO, Country>();
            CreateMap<TagDTO, Tag>();


            CreateMap<CreateContributorProfileDTO, Contributor>();
            CreateMap<ContributorSignupRequestDTO, Contributor>();
            CreateMap<Contributor, ContributorSignupResponseDTO>();
            
            CreateMap<ContributorLoginRequestDTO, Contributor>();
            CreateMap<Contributor, ContributorLoginResponseDTO>();

            CreateMap<Organization, GetOrganizationProfileDTO>();
            CreateMap<Organization, OrganizationInfoDTO>();
            CreateMap<GetOrganizationProfileDTO, Organization>();


            

        }
    }
}