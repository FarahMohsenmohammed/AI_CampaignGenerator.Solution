using AI_CampaignGenerator.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Shared.DTOS.CampaignDTOS
{
   public class CampaignDTO
    {
        public int Id { get; set; }
        public string Campaign_Name { get; set; } = default!; 
        public DateTime CreatedAt { get; set; }
        public  CampaignStatus Status { get; set; }
        public DateTime? EndDate { get; set; }

        public string? Platform { get; set; }
        public string CampaignGoal { get; set; } = default!;
    }
}
