namespace ShopCoApi.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; } = null!;
        public int Quantity { get; set; }
    }
}