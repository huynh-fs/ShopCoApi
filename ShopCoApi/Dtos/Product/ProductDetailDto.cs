namespace ShopCoApi.Dtos.Product
{
    // DTOs con để giữ cấu trúc JSON gọn gàng
    public class ImageDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
    }

    public class ReviewDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public double Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime PostedDate { get; set; }
    }

    public class VariantDto
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; } = string.Empty;
        public string ColorHexCode { get; set; } = string.Empty;
        public int SizeId { get; set; }
        public string SizeName { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal? OriginalPrice { get; set; }
        public int? DiscountPercentage { get; set; }
    }

    // DTO chính cho trang chi tiết
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double AverageRating { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? ParentCategoryName { get; set; }

        public List<ImageDto> Images { get; set; } = new();
        public List<ReviewDto> Reviews { get; set; } = new();
        public List<VariantDto> Variants { get; set; } = new();
    }
}