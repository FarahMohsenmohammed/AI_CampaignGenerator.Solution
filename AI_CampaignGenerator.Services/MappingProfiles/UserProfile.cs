using AI_CampaignGenerator.Domain.Entities.UserModule;
using AI_CampaignGenerator.Shared.DTOS.UserDTOS;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services.MappingProfiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            //user=>userdto
            CreateMap<User,UserDTO>()
                .ForMember(dest=>dest.FullName,opt=>opt.MapFrom(src=>$"{src.FirstName}{src.LastName}"));
            //user=>userDetailsdto
            CreateMap<User, UserDetailsDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName}{src.LastName}"));
            //createuserdto=>user
            CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.JoinDate, opt => opt.Ignore());
            //join date will be taked from baseentity
        }

    }
}
