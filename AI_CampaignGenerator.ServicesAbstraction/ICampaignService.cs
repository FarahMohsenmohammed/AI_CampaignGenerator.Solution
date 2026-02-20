using AI_CampaignGenerator.Shared;
using AI_CampaignGenerator.Shared.DTOS.CampaignDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.ServicesAbstraction
{
    public interface ICampaignService
    {
        Task<PaginatedResult<CampaignDTO>> GetCampaignAsync(CampaignQueryParams queryParams);
        Task<CampaignDTO?> GetCampaignByIdAsync(int campaginId);
        Task<CampaignDTO> CreateCampaignAsync(int userId,CreateCampaignDTO dto);
        Task<bool>DeleteCampaignAsync(int campaginId);


    }
}
