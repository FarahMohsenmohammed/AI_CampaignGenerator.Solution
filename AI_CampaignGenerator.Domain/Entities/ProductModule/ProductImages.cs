using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Domain.Entities.ProductModule
{
  public class ProductImages:BaseEntity<int>
    {
        public string ImageURL { get; set; } = default!;
        // prod-prodimages 1 to m
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;

    }
}
