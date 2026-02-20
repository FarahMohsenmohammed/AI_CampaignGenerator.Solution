using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using AI_CampaignGenerator.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services.Specifications
{
    internal class CampaignByUserSpecification:BaseSpecifications<Campaign,int>
    {
        public CampaignByUserSpecification(CampaignQueryParams queryParams):base(c=>!queryParams.UserId.HasValue||c.UserId==queryParams.UserId)
        {
           AddInclude(c=>c.User);
            ApplyPagination(queryParams.PageSize, queryParams.PageIndex);
        }
    }
}
