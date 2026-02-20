using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using AI_CampaignGenerator.Shared.DTOS.CampaignDTOS;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services.MappingProfiles
{
  public class CampaignProfile:Profile
    {
        public CampaignProfile()
        {
            //campaign=>campaigndto
            CreateMap<Campaign, CampaignDTO>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            //createcampaigndto=>campaign
            CreateMap<CreateCampaignDTO, Campaign>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore());
        }
    }
}
