namespace ShopCoApi.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}