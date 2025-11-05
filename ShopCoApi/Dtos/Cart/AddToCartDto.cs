using System.ComponentModel.DataAnnotations;

namespace ShopCoApi.Dtos.Cart
{
    public class AddToCartDto
    {
        [Required]
        public int ProductVariantId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}