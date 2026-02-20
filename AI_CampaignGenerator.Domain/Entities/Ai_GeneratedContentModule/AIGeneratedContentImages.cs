using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Domain.Entities.Ai_GeneratedContentModule
{
    public class AIGeneratedContentImages:BaseEntity<int>
    {
        public string GeneratedImageURL { get; set; } = default!;
        //Aigeneratedcontent 1to m
        //fk
        public int ContentId { get; set; }
        public AIGeneratedContent Content { get; set; } =default!;
    }
}
