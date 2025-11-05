namespace ShopCoApi.Dtos.Product
{
    public class ProductListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public double AverageRating { get; set; }
        public string? PrimaryImageUrl { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}