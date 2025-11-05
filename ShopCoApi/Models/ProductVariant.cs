using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCoApi.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;

        public int SizeId { get; set; }
        public Size Size { get; set; } = null!;

        public int StockQuantity { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? OriginalPrice { get; set; }

        [NotMapped]
        public int? DiscountPercentage
        {
            get
            {
                if (OriginalPrice.HasValue && OriginalPrice.Value > Price)
                {
                    var discount = (1 - (Price / OriginalPrice.Value)) * 100;
                    return (int)Math.Round(discount);
                }
                return null;
            }
        }
    }
}