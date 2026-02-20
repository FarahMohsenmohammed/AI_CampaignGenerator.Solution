using AI_CampaignGenerator.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Shared.DTOS.AiGeneratedContentDTOS
{
  public class CreateAIGeneratedContentDTO
    {
        //public int CampaignId { get; set; }
        public ContentLanguage Language { get; set; }
        public string Season { get; set; } = default!;
        public string AdTone { get; set; }= default!;
        public string ImagePrompt { get; set; } = default!;

    }
}
