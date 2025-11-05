namespace ShopCoApi.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Url { get; set; } = String.Empty;
        public bool IsPrimary { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}