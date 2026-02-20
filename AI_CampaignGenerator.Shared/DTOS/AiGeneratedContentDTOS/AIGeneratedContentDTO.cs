using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_CampaignGenerator.Domain.Entities.Enums;

namespace AI_CampaignGenerator.Shared.DTOS.AiGeneratedContentDTOS
{
    public class AIGeneratedContentDTO
    {
        public string IdealHashtags { get; set; } = default!;
        public string IdealCaption { get; set; } = default!;
        public ContentLanguage Language { get; set; }
        public List<string> GeneratedImageUrls { get; set; } = new();

    }
}
