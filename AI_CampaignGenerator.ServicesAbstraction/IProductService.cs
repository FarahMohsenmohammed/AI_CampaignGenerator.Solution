using AI_CampaignGenerator.Shared.DTOS.ProductDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.ServicesAbstraction
{
   public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync(int userId);
        Task<ProductDTO?>GetProductByIdAsync(int id);
        Task<ProductDTO> CreateProductAsync(int userId, CreateProductDTO dto);
       Task<ProductDTO?> UpdateProductAsync(int id, CreateProductDTO dto);
        Task<bool> DeleteProductAsync(int id);
    }
}
