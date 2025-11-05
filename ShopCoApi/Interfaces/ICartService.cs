using ShopCoApi.Dtos.Cart;

namespace ShopCoApi.Interfaces
{
    public interface ICartService
    {
        Task<CartDto?> GetCartAsync();
        Task<CartDto?> AddItemToCartAsync(AddToCartDto itemDto);
        Task<CartDto?> UpdateItemQuantityAsync(int cartItemId, int quantity);
        Task<CartDto?> RemoveItemAsync(int cartItemId);
        Task<CartDto?> SynchronizeCartAsync(CartDto guestCart);
    }
}
