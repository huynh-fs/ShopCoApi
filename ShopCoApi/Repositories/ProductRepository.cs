using Microsoft.EntityFrameworkCore;
using ShopCoApi.Data;
using ShopCoApi.Interfaces;
using ShopCoApi.Models;

namespace ShopCoApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            // Câu lệnh truy vấn phức tạp giờ nằm gọn trong Repository
            return await _context.Products
                                 .Include(p => p.Category.ParentCategory)
                                 .Include(p => p.Images)
                                 .Include(p => p.Reviews)
                                 .Include(p => p.Variants)
                                     .ThenInclude(v => v.Color)
                                 .Include(p => p.Variants)
                                     .ThenInclude(v => v.Size)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products
                                 .Include(p => p.Images)
                                 .Include(p => p.Category)
                                 .ToListAsync();
        }
    }
}