using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopCoApi.Models;

namespace ShopCoApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductFaq> ProductFaqs { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CATEGORIES 
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Men", ParentCategoryId = null },
                new Category { Id = 2, Name = "Women", ParentCategoryId = null },
                new Category { Id = 3, Name = "T-Shirts", ParentCategoryId = 1 }, // Con của Men
                new Category { Id = 4, Name = "Shirts", ParentCategoryId = 1 },   // Con của Men
                new Category { Id = 5, Name = "Jeans", ParentCategoryId = 1 },    // Con của Men
                new Category { Id = 6, Name = "Dresses", ParentCategoryId = 2 }   // Con của Women
            );

            // COLORS
            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Black", HexCode = "#000000" },
                new Color { Id = 2, Name = "White", HexCode = "#FFFFFF" },
                new Color { Id = 3, Name = "Olive", HexCode = "#4F4631" },
                new Color { Id = 4, Name = "Navy", HexCode = "#31344F" },
                new Color { Id = 5, Name = "Red", HexCode = "#FF0000" },
                new Color { Id = 6, Name = "Blue", HexCode = "#0000FF" }
            );

            // SIZES
            modelBuilder.Entity<Size>().HasData(
                new Size { Id = 1, Name = "Small" },
                new Size { Id = 2, Name = "Medium" },
                new Size { Id = 3, Name = "Large" },
                new Size { Id = 4, Name = "X-Large" }
            );

            // PRODUCTS
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "ONE LIFE GRAPHIC T-SHIRT",
                    Description = "This graphic t-shirt which is perfect for any occasion. Crafted from a soft and breathable fabric, it offers superior comfort and style.",
                    DetailedDescription = "Made from 100% premium ring-spun cotton, this t-shirt features a unique graphic print designed by our in-house artists. The fabric is pre-shrunk to maintain its shape after washing, and the fit is a modern, slightly tapered cut.",
                    BasePrice = 30.00m,
                    AverageRating = 4.5,
                    CategoryId = 3 // T-Shirts
                },
                new Product
                {
                    Id = 2,
                    Name = "Skinny Fit Jeans",
                    Description = "A modern take on a classic, these skinny fit jeans offer a sleek silhouette and all-day comfort. Made with stretch denim for a perfect fit.",
                    DetailedDescription = "Our skinny fit jeans are crafted from a high-quality denim blend (98% cotton, 2% elastane) for the perfect combination of structure and stretch. Features a classic five-pocket design, zip fly, and a branded leather patch on the back.",
                    BasePrice = 75.00m,
                    AverageRating = 4.2,
                    CategoryId = 5 // Jeans
                },
                new Product
                {
                    Id = 3,
                    Name = "Classic Checkered Shirt",
                    Description = "A timeless checkered shirt that adds a touch of rustic charm to your wardrobe. Made from 100% premium cotton.",
                    DetailedDescription = "This versatile shirt is perfect for layering or wearing on its own. It features a button-down collar, a single chest pocket, and adjustable cuffs. The flannel fabric is soft to the touch and provides warmth on cooler days.",
                    BasePrice = 55.00m,
                    AverageRating = 4.8,
                    CategoryId = 4 // Shirts
                }
            );

            // PRODUCT IMAGES
            modelBuilder.Entity<ProductImage>().HasData(
                // Images for Product 1
                new ProductImage { Id = 1, Url = "https://cdn.pixabay.com/photo/2024/04/29/04/21/tshirt-8726716_1280.jpg", IsPrimary = true, ProductId = 1 },
                new ProductImage { Id = 2, Url = "https://tse3.mm.bing.net/th/id/OIP.XbpNO0eM9CaAjnmV16uibwHaHa?pid=ImgDet&w=203&h=203&c=7&o=7&rm=3", IsPrimary = false, ProductId = 1 },
                new ProductImage { Id = 3, Url = "https://tse1.mm.bing.net/th/id/OIP.AT3AZiJg2Z04rkIJV0OZWAHaHa?pid=ImgDet&w=203&h=203&c=7&o=7&rm=3", IsPrimary = false, ProductId = 1 },
                // Images for Product 2
                new ProductImage { Id = 4, Url = "https://th.bing.com/th/id/OIF.pWER61jZ9Co6Xr1SZGIfYg?w=203&h=254&c=7&r=0&o=7&pid=1.7&rm=3", IsPrimary = true, ProductId = 2 },
                // Images for Product 3
                new ProductImage { Id = 5, Url = "https://th.bing.com/th/id/OIP.e__xPKL6FeicKbfiRqli1AHaJ4?w=148&h=198&c=7&r=0&o=7&pid=1.7&rm=3", IsPrimary = true, ProductId = 3 }
            );

            // PRODUCT VARIANTS (MÀU SẮC, KÍCH CỠ, TỒN KHO)
            modelBuilder.Entity<ProductVariant>().HasData(
                // Variants for Product 1 (T-Shirt)
                new ProductVariant { Id = 1, ProductId = 1, ColorId = 3, SizeId = 2, StockQuantity = 20, Price = 25.00m, OriginalPrice = 30.00m }, // Olive, M
                new ProductVariant { Id = 2, ProductId = 1, ColorId = 3, SizeId = 3, StockQuantity = 15, Price = 30.00m, OriginalPrice = 30.00m }, // Olive, L
                new ProductVariant { Id = 3, ProductId = 1, ColorId = 4, SizeId = 2, StockQuantity = 25, Price = 30.00m, OriginalPrice = null }, // Navy, M
                new ProductVariant { Id = 4, ProductId = 1, ColorId = 4, SizeId = 3, StockQuantity = 10, Price = 30.00m, OriginalPrice = null }, // Navy, L
                                                                                                                                                 // Variants for Product 2 (Jeans)
                new ProductVariant { Id = 5, ProductId = 2, ColorId = 6, SizeId = 1, StockQuantity = 12, Price = 75.00m, OriginalPrice = 65.00m }, // Blue, S
                new ProductVariant { Id = 6, ProductId = 2, ColorId = 6, SizeId = 2, StockQuantity = 30, Price = 75.00m, OriginalPrice = null }, // Blue, M
                new ProductVariant { Id = 7, ProductId = 2, ColorId = 6, SizeId = 3, StockQuantity = 18, Price = 75.00m, OriginalPrice = null }, // Blue, L
                                                                                                                                                 // Variants for Product 3 (Shirt)
                new ProductVariant { Id = 8, ProductId = 3, ColorId = 5, SizeId = 3, StockQuantity = 22, Price = 55.00m, OriginalPrice = null } // Red, L
            );

            // REVIEWS
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    AuthorName = "Samantha D.",
                    Rating = 4.5,
                    Comment = "I absolutely love this t-shirt! The design is unique and the fabric feels so comfortable.",
                    PostedDate = new DateTime(2023, 8, 14, 0, 0, 0, DateTimeKind.Utc),
                    ProductId = 1
                },
                new Review
                {
                    Id = 2,
                    AuthorName = "Alex M.",
                    Rating = 5,
                    Comment = "The quality is top-notch. It's become my favorite go-to shirt.",
                    PostedDate = new DateTime(2023, 8, 15, 0, 0, 0, DateTimeKind.Utc),
                    ProductId = 1
                },
                new Review
                {
                    Id = 3,
                    AuthorName = "Ethan R.",
                    Rating = 4,
                    Comment = "These jeans fit perfectly. The stretch material is very comfortable for all-day wear.",
                    PostedDate = new DateTime(2023, 8, 16, 0, 0, 0, DateTimeKind.Utc),
                    ProductId = 2
                }
            );

            // PRODUCT FAQS
            modelBuilder.Entity<ProductFaq>().HasData(
                new ProductFaq { Id = 1, Question = "What is the return policy?", Answer = "We offer a 30-day return policy for all unworn items.", ProductId = 1 },
                new ProductFaq { Id = 2, Question = "What material is this t-shirt made of?", Answer = "This t-shirt is made from 100% premium ring-spun cotton.", ProductId = 1 },
                new ProductFaq { Id = 3, Question = "How do I wash these jeans?", Answer = "We recommend washing inside out in cold water and hanging to dry to preserve the color and fit.", ProductId = 2 }
            );
        }
    }
}
