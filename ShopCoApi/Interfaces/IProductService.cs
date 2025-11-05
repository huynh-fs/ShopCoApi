using ShopCoApi.Dtos.Product;

namespace ShopCoApi.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListItemDto>> GetProductsAsync();
        Task<ProductDetailDto?> GetProductByIdAsync(int id);
    }
}