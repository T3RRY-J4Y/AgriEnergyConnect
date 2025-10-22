using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect.Models;
using System;

namespace AgriEnergyConnect.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Farmers
            modelBuilder.Entity<Farmer>().HasData(
                new Farmer { Id = 1, Name = "Xikombiso Dlamini", Location = "Pretoria" },
                new Farmer { Id = 2, Name = "Rihlatlho Mavhungu", Location = "Johannesburg" },
                new Farmer { Id = 3, Name = "Tiyani Phiri", Location = "Nelspruit" },
                new Farmer { Id = 4, Name = "Lufuno Shongwe", Location = "Polokwane" },
                new Farmer { Id = 5, Name = "Nyiko Tshabalala", Location = "Soweto" },
                new Farmer { Id = 6, Name = "Rendani Mokoena", Location = "Tzaneen" },
                new Farmer { Id = 7, Name = "Khensani Ndlovu", Location = "Mbombela" },
                new Farmer { Id = 8, Name = "Tsakani Hlabangana", Location = "Thohoyandou" },
                new Farmer { Id = 9, Name = "Vutomi Ramabulana", Location = "Polokwane" },
                new Farmer { Id = 10, Name = "Mandla Maphosa", Location = "Pretoria" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                // 1
                new Product { Id = 1, Name = "Corn", Category = "Grain", ProductionDate = DateTime.UtcNow, FarmerId = 1 },
                new Product { Id = 2, Name = "Pumpkin", Category = "Vegetable", ProductionDate = DateTime.UtcNow, FarmerId = 1 },

                // 2
                new Product { Id = 3, Name = "Sorghum", Category = "Grain", ProductionDate = DateTime.UtcNow, FarmerId = 2 },
                new Product { Id = 4, Name = "Tomato", Category = "Vegetable", ProductionDate = DateTime.UtcNow, FarmerId = 2 },

                // 3
                new Product { Id = 5, Name = "Peanuts", Category = "Legume", ProductionDate = DateTime.UtcNow, FarmerId = 3 },
                new Product { Id = 6, Name = "Spinach", Category = "Vegetable", ProductionDate = DateTime.UtcNow, FarmerId = 3 },

                // 4
                new Product { Id = 7, Name = "Maize", Category = "Grain", ProductionDate = DateTime.UtcNow, FarmerId = 4 },
                new Product { Id = 8, Name = "Cabbage", Category = "Vegetable", ProductionDate = DateTime.UtcNow, FarmerId = 4 },

                // 5
                new Product { Id = 9, Name = "Soy", Category = "Legume", ProductionDate = DateTime.UtcNow, FarmerId = 5 },
                new Product { Id = 10, Name = "Carrot", Category = "Vegetable", ProductionDate = DateTime.UtcNow, FarmerId = 5 },

                // 6
                new Product { Id = 11, Name = "Wheat", Category = "Grain", ProductionDate = DateTime.UtcNow, FarmerId = 6 },
                new Product { Id = 12, Name = "Beetroot", Category = "Vegetable", ProductionDate = DateTime.UtcNow, FarmerId = 6 },

                // 7
                new Product { Id = 13, Name = "Barley", Category = "Grain", ProductionDate = DateTime.UtcNow, FarmerId = 7 },
                new Product { Id = 14, Name = "Chili", Category = "Vegetable", ProductionDate = DateTime.UtcNow, FarmerId = 7 },

                // 8
                new Product { Id = 15, Name = "Millet", Category = "Grain", ProductionDate = DateTime.UtcNow, FarmerId = 8 },
                new Product { Id = 16, Name = "Onion", Category = "Vegetable", ProductionDate = DateTime.UtcNow, FarmerId = 8 },

                // 9
                new Product { Id = 17, Name = "Cowpeas", Category = "Legume", ProductionDate = DateTime.UtcNow, FarmerId = 9 },
                new Product { Id = 18, Name = "Lettuce", Category = "Vegetable", ProductionDate = DateTime.UtcNow, FarmerId = 9 },

                // 10
                new Product { Id = 19, Name = "Chickpeas", Category = "Legume", ProductionDate = DateTime.UtcNow, FarmerId = 10 },
                new Product { Id = 20, Name = "Cucumber", Category = "Vegetable", ProductionDate = DateTime.UtcNow, FarmerId = 10 }
            );
        }
    }
}
