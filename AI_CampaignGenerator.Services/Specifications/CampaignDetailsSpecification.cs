using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services.Specifications
{
    internal class CampaignDetailsSpecification:BaseSpecifications<Campaign,int>
    {
        public CampaignDetailsSpecification(int campaignId):base(c=>c.Id==campaignId)
        {
            AddInclude(c => c.User); 
        }
    }
}
