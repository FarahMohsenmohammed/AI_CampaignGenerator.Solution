using AI_CampaignGenerator.Domain.Contracts;
using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using AI_CampaignGenerator.Domain.Entities.Enums;
using AI_CampaignGenerator.Services.Specifications;
using AI_CampaignGenerator.ServicesAbstraction;
using AI_CampaignGenerator.Shared;
using AI_CampaignGenerator.Shared.DTOS.CampaignDTOS;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CampaignService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
           _mapper = mapper;
        }
        public async Task<PaginatedResult<CampaignDTO>> GetCampaignAsync(CampaignQueryParams queryParams)
        {
            var repo = _unitOfWork.GetRepository<Campaign, int>();
            var spec = new CampaignByUserSpecification(queryParams);
            var campaigns= await repo.GetAllAsync(spec);
            var countspec=new CampaignCountSpecification(queryParams);
            var totalcount=(await repo.GetAllAsync(countspec)).Count();
            var mappeddata=_mapper.Map<IReadOnlyList<CampaignDTO>>(campaigns);
            return new PaginatedResult<CampaignDTO>(
                queryParams.PageIndex,
                queryParams.PageSize,
                totalcount,
                mappeddata
                );
            
        }

        public async Task<CampaignDTO?> GetCampaignByIdAsync(int campaginId)
        {
         var spec=new CampaignDetailsSpecification(campaginId);
            var campagins=await _unitOfWork.GetRepository<Campaign,int>().GetAllAsync(spec);
            var campaign=campagins.FirstOrDefault();
            if (campaign is null)
                return null;
            return _mapper.Map<CampaignDTO>(campaign);
        }
        public async Task<CampaignDTO> CreateCampaignAsync(int userId, CreateCampaignDTO dto)
        {
            var campaign=_mapper.Map<Campaign>(dto);
            campaign.UserId = userId;
            campaign.CreatedAt= DateTime.UtcNow;
            campaign.Status = CampaignStatus.Pending;
            await _unitOfWork.GetRepository<Campaign,int>().AddAsync(campaign);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CampaignDTO>(campaign);

        }

        public async Task<bool> DeleteCampaignAsync(int campaginId)
        {
            var repo = _unitOfWork.GetRepository<Campaign, int>();
            var campaign=await repo.GetByIdAsync(campaginId);
            if(campaign is null) return false;
            repo.Remove(campaign);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }


    }
}
