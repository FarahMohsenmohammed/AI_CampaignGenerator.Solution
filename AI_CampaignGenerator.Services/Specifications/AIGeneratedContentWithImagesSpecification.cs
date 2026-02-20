using AI_CampaignGenerator.Domain.Entities.Ai_GeneratedContentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services.Specifications
{
   public class AIGeneratedContentWithImagesSpecification:BaseSpecifications<AIGeneratedContent,int>
    {
        public AIGeneratedContentWithImagesSpecification(int id):base(a=>a.Id==id)
        {
            AddInclude(a => a.Images);
        }
    }
}
