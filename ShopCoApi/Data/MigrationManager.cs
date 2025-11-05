// Data/MigrationManager.cs
using Microsoft.EntityFrameworkCore;

namespace ShopCoApi.Data
{
    public static class MigrationManager
    {
        public static async Task ApplyMigrationsAsync(IServiceProvider services)
        {
            // Sử dụng 'using' để đảm bảo DbContext được giải phóng đúng cách
            using (var scope = services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                try
                {
                    logger.LogInformation("Checking for pending database migrations...");

                    // Lấy danh sách các migration chưa được áp dụng
                    var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

                    if (pendingMigrations.Any())
                    {
                        logger.LogInformation("Applying {Count} pending migrations...", pendingMigrations.Count());
                        // Áp dụng các migration còn thiếu vào database
                        await dbContext.Database.MigrateAsync();
                        logger.LogInformation("Database migrations applied successfully.");
                    }
                    else
                    {
                        logger.LogInformation("Database is up to date. No migrations to apply.");
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while applying database migrations.");
                    // Ném lại lỗi để ứng dụng không khởi động nếu migration thất bại
                    throw;
                }
            }
        }
    }
}