namespace ShopCoApi.Dtos.Cart
{
    public class CartDto
    {
        public int Id { get; set; }
        public List<CartItemDto> Items { get; set; } = new();
        public int TotalItems => Items.Sum(item => item.Quantity);
        public decimal GrandTotal => Items.Sum(item => item.TotalPrice);
    }
}