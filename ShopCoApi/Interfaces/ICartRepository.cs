using ShopCoApi.Models;

namespace ShopCoApi.Interfaces
{
    public interface ICartRepository
    {
        Task<ShoppingCart?> GetCartByUserIdAsync(string userId);
        Task<ShoppingCart> CreateCartForUserAsync(string userId);
        Task<CartItem?> GetCartItemAsync(int cartId, int productVariantId);
        Task<CartItem?> GetCartItemByIdAsync(int cartItemId);
        Task AddCartItemAsync(CartItem item);
        void RemoveCartItem(CartItem item);
        Task<int> SaveChangesAsync();
    }
}