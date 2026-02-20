using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using AI_CampaignGenerator.Domain.Entities.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Domain.Entities.ProductModule
{
    public class Product:BaseEntity<int>
    {
        //createsAt=Date of base (will be reused)
        public string ProductCategory { get; set; } = default!;
        public string ProductSubCategry { get; set; } = default!;
        public string Material {  get; set; } = default!;
        public string ProductName { get; set; } =default!;
        public string? ProductDescription { get; set; }
        public string GenderFocus { get; set; } = default!;
        public string TargetAudiencePersona { get; set; } = default!;
        public string? USP { get; set; }
        

        #region user_product 1to m
        //fk
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        #endregion
        #region prod - prodimages 1 to M 
        public ICollection<ProductImages> ProductImages { get; set; } = new List<ProductImages>();

        #endregion
        //prod-campaigns 1to m
        public ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();



    }
}
