using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Shared.DTOS.CampaignDTOS
{
 public class CreateCampaignDTO
    {
        public string Campaign_Name { get; set; } = default!;
        public DateTime? EndDate { get; set; }
        public string? Platform { get; set; }
        public string CampaignGoal { get; set; } = default!;
        public int ProductId { get; set; }
    }
}
