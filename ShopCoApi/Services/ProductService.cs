using AutoMapper;
using ShopCoApi.Dtos.Product;
using ShopCoApi.Interfaces;
using ShopCoApi.Models;

namespace ShopCoApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDetailDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return null;

            // Dùng AutoMapper để chuyển đổi
            return _mapper.Map<ProductDetailDto>(product);
        }

        public async Task<IEnumerable<ProductListItemDto>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();

            // Dùng AutoMapper để chuyển đổi
            return _mapper.Map<IEnumerable<ProductListItemDto>>(products);
        }
    }
}