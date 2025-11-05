using AutoMapper;
using ShopCoApi.Data;
using ShopCoApi.Dtos.Cart;
using ShopCoApi.Interfaces;
using ShopCoApi.Models;
using System.Security.Claims;

namespace ShopCoApi.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;

        public CartService(ICartRepository cartRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<CartDto?> GetCartAsync()
        {
            var cart = await GetOrCreateCartForCurrentUserAsync();
            if (cart == null) return null;
            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto?> AddItemToCartAsync(AddToCartDto itemDto)
        {
            var cart = await GetOrCreateCartForCurrentUserAsync();
            if (cart == null) return null;

            var cartItem = await _cartRepository.GetCartItemAsync(cart.Id, itemDto.ProductVariantId);

            if (cartItem != null)
            {
                cartItem.Quantity += itemDto.Quantity;
            }
            else
            {
                cartItem = new CartItem
                {
                    ShoppingCartId = cart.Id,
                    ProductVariantId = itemDto.ProductVariantId,
                    Quantity = itemDto.Quantity,
                };
                await _cartRepository.AddCartItemAsync(cartItem);
            }

            await _cartRepository.SaveChangesAsync();
            return _mapper.Map<CartDto>(cart);
        }

        public async Task<CartDto?> UpdateItemQuantityAsync(int cartItemId, int quantity)
        {
            var cart = await GetOrCreateCartForCurrentUserAsync();
            if (cart == null) return null;

            var cartItem = cart.Items.FirstOrDefault(i => i.Id == cartItemId);
            if (cartItem == null) return null;

            if (quantity <= 0)
            {
                _cartRepository.RemoveCartItem(cartItem);
            }
            else
            {
                var variant = await _context.ProductVariants.FindAsync(cartItem.ProductVariantId);
                if (variant == null || variant.StockQuantity < quantity) return null;
                cartItem.Quantity = quantity;
            }

            await _cartRepository.SaveChangesAsync();
            return _mapper.Map<CartDto?>(cart);
        }

        public async Task<CartDto?> RemoveItemAsync(int cartItemId)
        {
            var cart = await GetOrCreateCartForCurrentUserAsync();
            if (cart == null) return null;

            var cartItem = cart.Items.FirstOrDefault(i => i.Id == cartItemId);
            if (cartItem == null) return null;

            _cartRepository.RemoveCartItem(cartItem);
            await _cartRepository.SaveChangesAsync();

            return _mapper.Map<CartDto?>(cart);
        }

        public async Task<CartDto?> SynchronizeCartAsync(CartDto guestCart)
        {
            var userCart = await GetOrCreateCartForCurrentUserAsync();
            if (userCart == null) return null;

            foreach (var guestCartItem in guestCart.Items)
            {
                var userCartItem = userCart.Items.FirstOrDefault(i => i.ProductVariantId == guestCartItem.ProductVariantId);

                if (userCartItem != null)
                {
                    userCartItem.Quantity += guestCartItem.Quantity;
                }
                else
                {
                    var newItem = new CartItem
                    {
                        ShoppingCartId = userCart.Id,
                        ProductVariantId = guestCartItem.ProductVariantId,
                        Quantity = guestCartItem.Quantity,
                    };
                    await _cartRepository.AddCartItemAsync(newItem);
                }
            }

            await _cartRepository.SaveChangesAsync();

            var finalCart = await _cartRepository.GetCartByUserIdAsync(userCart.UserId);
            return _mapper.Map<CartDto>(finalCart);
        }

        private async Task<ShoppingCart?> GetOrCreateCartForCurrentUserAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var user = httpContext?.User;

            if (user == null || user.Identity?.IsAuthenticated != true)
            {
                return null;
            }

            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return null;

            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                cart = await _cartRepository.CreateCartForUserAsync(userId);
                await _cartRepository.SaveChangesAsync();
            }

            return cart;
        }
    }
}
