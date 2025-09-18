using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect.Models;

namespace AgriEnergyConnect.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await context.Database.MigrateAsync();

            // Roles
            if (!await roleManager.RoleExistsAsync("Farmer"))
                await roleManager.CreateAsync(new IdentityRole("Farmer"));

            if (!await roleManager.RoleExistsAsync("Employee"))
                await roleManager.CreateAsync(new IdentityRole("Employee"));

            // Seed Users
            var farmerUser = new ApplicationUser { UserName = "farmer@test.com", Email = "farmer@test.com" };
            if (userManager.Users.All(u => u.UserName != farmerUser.UserName))
            {
                await userManager.CreateAsync(farmerUser, "Farmer123!");
                await userManager.AddToRoleAsync(farmerUser, "Farmer");
            }

            var employeeUser = new ApplicationUser { UserName = "employee@test.com", Email = "employee@test.com" };
            if (userManager.Users.All(u => u.UserName != employeeUser.UserName))
            {
                await userManager.CreateAsync(employeeUser, "Employee123!");
                await userManager.AddToRoleAsync(employeeUser, "Employee");
            }

            // Seed Farmers + Products
            if (!context.Farmers.Any())
            {
                var farmer = new Farmer { Name = "John Doe", Location = "Pretoria" };
                context.Farmers.Add(farmer);
                context.Products.Add(new Product
                {
                    Name = "Organic Maize",
                    Category = "Crops",
                    ProductionDate = DateTime.UtcNow.AddMonths(-2),
                    Farmer = farmer
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
