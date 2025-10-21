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

            // Apply migrations
            await context.Database.MigrateAsync();

            // Seed Roles
            string[] roles = { "Farmer", "Employee" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Seed Employees/Admins
            var employees = new List<(string Email, string Password)>
            {
                ("admin@agrienergy.com", "Admin@123"),
                ("employee@test.com", "Employee123!")
            };

            foreach (var (email, password) in employees)
            {
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new ApplicationUser { UserName = email, Email = email };
                    await userManager.CreateAsync(user, password);
                    await userManager.AddToRoleAsync(user, "Employee");
                }
            }

            // Seed Farmers + Products (with user accounts)
            if (!context.Farmers.Any())
            {
                var farmersData = new List<(string Name, string Location, string Email, string Password)>
                {
                    ("John Doe", "Pretoria", "farmer1@test.com", "Farmer123!"),
                    ("Mary Smith", "Johannesburg", "farmer2@test.com", "Farmer123!"),
                    ("Thabo Nkosi", "Durban", "farmer3@test.com", "Farmer123!")
                };

                foreach (var (name, location, email, password) in farmersData)
                {
                    // Create ApplicationUser
                    if (await userManager.FindByEmailAsync(email) == null)
                    {
                        var farmerUser = new ApplicationUser { UserName = email, Email = email };
                        await userManager.CreateAsync(farmerUser, password);
                        await userManager.AddToRoleAsync(farmerUser, "Farmer");

                        // Create Farmer profile
                        var farmerProfile = new Farmer { Name = name, Location = location };
                        context.Farmers.Add(farmerProfile);
                        await context.SaveChangesAsync();

                        // Link user to farmer profile
                        farmerUser.FarmerId = farmerProfile.Id;
                        await userManager.UpdateAsync(farmerUser);

                        // Seed sample products for each farmer
                        var products = new List<Product>();
                        if (name == "John Doe")
                        {
                            products.Add(new Product { Name = "Organic Maize", Category = "Crops", ProductionDate = DateTime.UtcNow.AddMonths(-2), FarmerId = farmerProfile.Id });
                            products.Add(new Product { Name = "Wheat", Category = "Crops", ProductionDate = DateTime.UtcNow.AddMonths(-1), FarmerId = farmerProfile.Id });
                        }
                        else if (name == "Mary Smith")
                        {
                            products.Add(new Product { Name = "Vegetables Box", Category = "Vegetables", ProductionDate = DateTime.UtcNow.AddMonths(-1), FarmerId = farmerProfile.Id });
                            products.Add(new Product { Name = "Tomatoes", Category = "Vegetables", ProductionDate = DateTime.UtcNow.AddMonths(-2), FarmerId = farmerProfile.Id });
                        }
                        else if (name == "Thabo Nkosi")
                        {
                            products.Add(new Product { Name = "Fresh Milk", Category = "Dairy", ProductionDate = DateTime.UtcNow.AddMonths(-1), FarmerId = farmerProfile.Id });
                            products.Add(new Product { Name = "Cheese", Category = "Dairy", ProductionDate = DateTime.UtcNow.AddMonths(-3), FarmerId = farmerProfile.Id });
                        }

                        context.Products.AddRange(products);
                        await context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
