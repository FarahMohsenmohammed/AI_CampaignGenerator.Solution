using AI_CampaignGenerator.Domain.Entities.ProductModule;
using AI_CampaignGenerator.Shared.DTOS.ProductDTOS;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services.MappingProfiles
{
   public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            //prod=>proddto
            CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.ProductImages.Select(img => img.ImageURL).ToList()));
            //createprod=>prod
            CreateMap<CreateProductDTO, Product>();
            //productimages=>string image url
            CreateMap<ProductImages, string>()
                .ConstructUsing(src => src.ImageURL);
        }
    }
}
