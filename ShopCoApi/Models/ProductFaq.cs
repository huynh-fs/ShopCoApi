namespace ShopCoApi.Models
{
    public class ProductFaq
    {
        public int Id { get; set; }
        public string Question { get; set; } = String.Empty;
        public string Answer { get; set; } = String.Empty;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}