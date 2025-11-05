using System.ComponentModel.DataAnnotations;

namespace ShopCoApi.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string AuthorName { get; set; } = String.Empty;

        [Range(1, 5)] // Rating từ 1 đến 5 sao
        public double Rating { get; set; }

        public string Comment { get; set; } = String.Empty;
        public DateTime PostedDate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
