using AI_CampaignGenerator.Domain.Contracts;
using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using AI_CampaignGenerator.Domain.Entities.Enums;
using AI_CampaignGenerator.Services.Exceptions;
using AI_CampaignGenerator.Services.Specifications;
using AI_CampaignGenerator.ServicesAbstraction;
using AI_CampaignGenerator.Shared;
using AI_CampaignGenerator.Shared.DTOS.CampaignDTOS;
using AutoMapper;

namespace AI_CampaignGenerator.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CampaignService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<CampaignDTO>> GetCampaignAsync(CampaignQueryParams queryParams)
        {
            var repo = _unitOfWork.GetRepository<Campaign, int>();

            var spec = new CampaignByUserSpecification(queryParams);
            var campaigns = await repo.GetAllAsync(spec);

            var countSpec = new CampaignCountSpecification(queryParams);
            var totalCount = (await repo.GetAllAsync(countSpec)).Count();

            var mapped = _mapper.Map<IReadOnlyList<CampaignDTO>>(campaigns);

            return new PaginatedResult<CampaignDTO>(
                queryParams.PageIndex,
                queryParams.PageSize,
                totalCount,
                mapped);
        }

        public async Task<CampaignDTO> GetCampaignByIdAsync(int campaignId)
        {
            var spec = new CampaignDetailsSpecification(campaignId);

            var campaigns = await _unitOfWork
                .GetRepository<Campaign, int>()
                .GetAllAsync(spec);

            var campaign = campaigns.FirstOrDefault();

            if (campaign is null)
                throw new CampaignNotFoundException(campaignId);

            return _mapper.Map<CampaignDTO>(campaign);
        }

        public async Task<CampaignDTO> CreateCampaignAsync(int userId, CreateCampaignDTO dto)
        {
            var campaign = _mapper.Map<Campaign>(dto);

            campaign.UserId = userId;
            campaign.CreatedAt = DateTime.UtcNow;
            campaign.Status = CampaignStatus.Pending;

            await _unitOfWork
                .GetRepository<Campaign, int>()
                .AddAsync(campaign);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CampaignDTO>(campaign);
        }

        public async Task DeleteCampaignAsync(int campaignId)
        {
            var repo = _unitOfWork.GetRepository<Campaign, int>();
            var campaign = await repo.GetByIdAsync(campaignId);

            if (campaign is null)
                throw new CampaignNotFoundException(campaignId);

            repo.Remove(campaign);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}