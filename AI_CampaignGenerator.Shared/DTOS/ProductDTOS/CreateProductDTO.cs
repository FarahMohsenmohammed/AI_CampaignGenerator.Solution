using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Shared.DTOS.ProductDTOS
{
   public class CreateProductDTO
    {
        public string ProductCategory { get; set; } = default!;
        public string ProductSubCategory { get; set; } = default!;
 
        public string ProductName { get; set; } = default!;
        
        public string Material { get; set; } = default!;
        public string? ProductDescription { get; set; }
        public string GenderFocus { get; set; } = default!;
        public string TargetAudiencePersona { get; set; } = default!;
        public string? USP { get; set; }
        //after apload
        public List<string> ImageUrls { get; set; } = new();
    }
}
