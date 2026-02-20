using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services.Specifications
{
   public class CampaignWithAIContentSpecification:BaseSpecifications<Campaign,int>
    {
        public CampaignWithAIContentSpecification(int campaignId):base(c=>c.Id==campaignId)
        {
            AddInclude(c => c.AIContents);
            AddInclude(c => c.AIContents.Select(ai => ai.Images));
            
        }
    }
}
