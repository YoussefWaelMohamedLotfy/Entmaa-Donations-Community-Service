using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Entmaa_Web_Services.DTOs.Auctions;
using Entmaa_Web_Services.DTOs.Donations;
using Entmaa_Web_Services.Models.Entmaa;

namespace Entmaa_Web_Services.Persistence.MapperProfiles
{
    public class AuctionMappingProfile : Profile
    {
        public AuctionMappingProfile()
        {
            CreateMap<CreateAuctionDTO, Auction>();
            CreateMap<EditAuctionDTO, Auction>();
            CreateMap<CreateBidderDTO, AuctionBidder>();

            CreateMap<Auction, GetAuctionsDTO>();
        }
    }
}