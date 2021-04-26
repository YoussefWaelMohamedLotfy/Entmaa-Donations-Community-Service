using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Entmaa_Web_Services.DTOs.Posts;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.MapperProfiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<CreatePostDTO, Post>();

            CreateMap<Post, GetOrganizationNewsDTO>();
            CreateMap<PostComment, CommentDTO>();
            CreateMap<Organization, UserDTO>();
        }
    }
}