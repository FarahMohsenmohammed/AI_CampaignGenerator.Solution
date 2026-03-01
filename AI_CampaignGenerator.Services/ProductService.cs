using AI_CampaignGenerator.Domain.Contracts;
using AI_CampaignGenerator.Domain.Entities.ProductModule;
using AI_CampaignGenerator.Services.Exceptions;
using AI_CampaignGenerator.Services.Specifications;
using AI_CampaignGenerator.ServicesAbstraction;
using AI_CampaignGenerator.Shared.DTOS.ProductDTOS;
using AutoMapper;

namespace AI_CampaignGenerator.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync(int userId)
        {
            var spec = new ProductByUserSpecification(userId);

            var products = await _unitOfWork
                .GetRepository<Product, int>()
                .GetAllAsync(spec);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork
                .GetRepository<Product, int>()
                .GetByIdAsync(id);

            if (product is null)
                throw new ProductNotFoundException(id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> CreateProductAsync(int userId, CreateProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            product.UserId = userId;

            await _unitOfWork
                .GetRepository<Product, int>()
                .AddAsync(product);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> UpdateProductAsync(int id, CreateProductDTO dto)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            var product = await repo.GetByIdAsync(id);

            if (product is null)
                throw new ProductNotFoundException(id);

            product.ProductName = dto.ProductName;
            product.ProductDescription = dto.ProductDescription;
            product.GenderFocus = dto.GenderFocus;
            product.TargetAudiencePersona = dto.TargetAudiencePersona;

            repo.Update(product);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            var product = await repo.GetByIdAsync(id);

            if (product is null)
                throw new ProductNotFoundException(id);

            repo.Remove(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}