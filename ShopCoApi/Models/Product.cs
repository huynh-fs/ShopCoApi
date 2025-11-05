using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCoApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string DetailedDescription { get; set; } = String.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal BasePrice { get; set; }

        public double AverageRating { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<ProductFaq> Faqs { get; set; } = new List<ProductFaq>();
    }
}