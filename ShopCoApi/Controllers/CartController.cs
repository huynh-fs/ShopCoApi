using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using ShopCoApi.Dtos.Cart;
using ShopCoApi.Interfaces;

namespace ShopCoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // GET: api/Cart
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var cartDto = await _cartService.GetCartAsync();
            if (cartDto == null)
            {
                return NotFound("Cart not found.");
            }
            return Ok(cartDto);
        }

        // POST: api/Cart/items
        [HttpPost("items")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto itemDto)
        {
            var updatedCart = await _cartService.AddItemToCartAsync(itemDto);
            if (updatedCart == null)
            {
                return BadRequest("Could not add item to cart.");
            }
            return Ok(updatedCart);
        }

        // PUT: api/Cart/items/5
        [HttpPut("items/{cartItemId}")]
        public async Task<IActionResult> UpdateItem(int cartItemId, [FromBody] UpdateQuantityDto dto)
        {
            var updatedCart = await _cartService.UpdateItemQuantityAsync(cartItemId, dto.Quantity);
            if (updatedCart == null)
            {
                return BadRequest(new { message = "Failed to update item. It may be out of stock or not found." });
            }
            return Ok(updatedCart);
        }

        // DELETE: api/Cart/items/5
        [HttpDelete("items/{cartItemId}")]
        public async Task<IActionResult> RemoveItem(int cartItemId)
        {
            var updatedCart = await _cartService.RemoveItemAsync(cartItemId);
            if (updatedCart == null)
            {
                return NotFound(new { message = "Item not found in cart." });
            }
            return Ok(updatedCart);
        }

        // POST: api/Cart/synchronize
        [HttpPost("synchronize")]
        public async Task<IActionResult> Synchronize([FromBody] CartDto guestCart)
        {
            var synchronizedCart = await _cartService.SynchronizeCartAsync(guestCart);
            if (synchronizedCart == null)
            {
                return BadRequest(new { message = "Could not synchronize cart." });
            }
            return Ok(synchronizedCart);
        }
    }
}