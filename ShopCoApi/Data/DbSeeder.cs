using Microsoft.AspNetCore.Identity;
using ShopCoApi.Models;

namespace ShopCoApi.Data
{
    public enum Roles
    {
        Admin,
        Customer
    }
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(Roles.Admin.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            }
            if (!await roleManager.RoleExistsAsync(Roles.Customer.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Customer.ToString()));
            }

            string adminEmail = "admin@shopco.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    EmailConfirmed = true
                };

                string adminPassword = "admin@123";
                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());
                }

            }

        }
    }
}
