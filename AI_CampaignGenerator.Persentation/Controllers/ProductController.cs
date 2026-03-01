using AI_CampaignGenerator.ServicesAbstraction;
using AI_CampaignGenerator.Shared.DTOS.ProductDTOS;
using Microsoft.AspNetCore.Mvc;

namespace AI_CampaignGenerator.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product?userId=1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts(
            [FromQuery] int userId)
        {
            var products =
                await _productService.GetAllProductsAsync(userId);

            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product =
                await _productService.GetProductByIdAsync(id);

            return Ok(product);
        }

        // POST: api/Product?userId=1
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct(
            [FromQuery] int userId,
            [FromBody] CreateProductDTO dto)
        {
            var createdProduct =
                await _productService.CreateProductAsync(userId, dto);

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = createdProduct.Id },
                createdProduct);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(
            int id,
            [FromBody] CreateProductDTO dto)
        {
            var updatedProduct =
                await _productService.UpdateProductAsync(id, dto);

            return Ok(updatedProduct);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}