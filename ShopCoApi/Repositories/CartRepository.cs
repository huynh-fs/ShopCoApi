using Microsoft.EntityFrameworkCore;
using ShopCoApi.Data;
using ShopCoApi.Interfaces;
using ShopCoApi.Models;
using System.Threading.Tasks;

namespace ShopCoApi.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ShoppingCart?> GetCartByUserIdAsync(string userId)
        {
            return await _context.ShoppingCarts
                .Include(c => c.Items)
                    .ThenInclude(i => i.ProductVariant)
                        .ThenInclude(pv => pv.Product)
                            .ThenInclude(p => p.Images)
                .Include(c => c.Items)
                    .ThenInclude(i => i.ProductVariant.Color)
                .Include(c => c.Items)
                    .ThenInclude(i => i.ProductVariant.Size)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<ShoppingCart> CreateCartForUserAsync(string userId)
        {
            var newCart = new ShoppingCart { UserId = userId, DateCreated = DateTime.UtcNow };
            await _context.ShoppingCarts.AddAsync(newCart);
            return newCart;
        }

        public async Task<CartItem?> GetCartItemAsync(int cartId, int productVariantId)
        {
            return await _context.CartItems.FirstOrDefaultAsync(ci => ci.ShoppingCartId == cartId && ci.ProductVariantId == productVariantId);
        }

        public async Task<CartItem?> GetCartItemByIdAsync(int cartItemId)
        {
            return await _context.CartItems.FindAsync(cartItemId);
        }

        public async Task AddCartItemAsync(CartItem item)
        {
            await _context.CartItems.AddAsync(item);
        }

        public void RemoveCartItem(CartItem item)
        {
            _context.CartItems.Remove(item);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
