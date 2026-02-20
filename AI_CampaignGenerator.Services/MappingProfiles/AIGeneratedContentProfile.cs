using AI_CampaignGenerator.Domain.Entities.Ai_GeneratedContentModule;
using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using AI_CampaignGenerator.Shared.DTOS.AiGeneratedContentDTOS;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services.MappingProfiles
{
    public class AIGeneratedContentProfile:Profile
    {
        public AIGeneratedContentProfile()
        {
            //aigenerated=>---dto
            CreateMap<AIGeneratedContent, AIGeneratedContentDTO>()
                .ForMember(dest => dest.GeneratedImageUrls, opt => opt.MapFrom(src => src.Images.Select(img => img.GeneratedImageURL).ToList()));
            //create=>ai generatedcontent
            CreateMap<CreateAIGeneratedContentDTO,AIGeneratedContent>()
                .ForMember(dest=>dest.IdealCaption,opt=>opt.Ignore())
                .ForMember(dest=>dest.IdealHashtags,opt=>opt.Ignore())
                .ForMember(dest=>dest.UploadedImageURL,opt=>opt.Ignore());
            //campaign=>campaignwithgeneratedcontentdto
            CreateMap<Campaign, CampaignWithGeneratedContentDTO>()
                .ForMember(dest => dest.CampaignId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CampaignName, opt => opt.MapFrom(src => src.Campaign_Name))
                .ForMember(dest => dest.GeneratedContents, opt => opt.MapFrom(src => src.AIContents));

        }
    }
}
