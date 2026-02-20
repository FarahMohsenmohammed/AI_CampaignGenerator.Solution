using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_CampaignGenerator.Domain.Entities.Enums;

namespace AI_CampaignGenerator.Shared.DTOS.AiGeneratedContentDTOS
{
    public class CampaignWithGeneratedContentDTO
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; } = default!;
        public CampaignStatus Status { get; set; }
        public List<AIGeneratedContentDTO> GeneratedContents { get; set; } = new();
    }
}
