using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using AI_CampaignGenerator.Domain.Entities.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Domain.Entities.UserModule
{
   public class User:BaseEntity<int>
    {
        //joindate==Date 
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime JoinDate { get; set; }

        #region user -products one to M
        public ICollection<Product> Products { get; set; } = new List<Product>();

        #endregion
        #region user-campaigns 1 to M 
        public ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();

        #endregion

    }
}
