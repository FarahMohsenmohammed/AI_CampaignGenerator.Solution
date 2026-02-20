using AI_CampaignGenerator.Domain.Entities.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services.Specifications
{
    internal class ProductByUserSpecification:BaseSpecifications<Product,int>
    {
        public ProductByUserSpecification(int userId):base(p=>p.UserId==userId)
        {
            
        }
    }
}
