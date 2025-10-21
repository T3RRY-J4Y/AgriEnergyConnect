using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;

namespace AgriEnergyConnect.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Farmer dashboard: view their own products
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> MyProducts()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user.FarmerId == null)
                return Unauthorized("You do not have a farmer profile.");

            var products = await _context.Products
                .Where(p => p.FarmerId == user.FarmerId)
                .ToListAsync();

            return View(products);
        }

        // Farmer dashboard: show create form
        [Authorize(Roles = "Farmer")]
        public IActionResult Create()
        {
            return View();
        }

        // Farmer dashboard: save new product
        [HttpPost]
        [Authorize(Roles = "Farmer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user.FarmerId == null)
                return Unauthorized("You do not have a farmer profile.");

            if (ModelState.IsValid)
            {
                // Set FarmerId automatically
                product.FarmerId = user.FarmerId.Value;

                // Set default ProductionDate if not provided
                if (product.ProductionDate == default)
                    product.ProductionDate = DateTime.UtcNow;

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                // Redirect to farmer's product list
                return RedirectToAction(nameof(MyProducts));
            }

            return View(product);
        }

        // Employee/Admin dashboard: view all products
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> AllProducts(string? category, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category.Contains(category));

            if (startDate.HasValue)
                query = query.Where(p => p.ProductionDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(p => p.ProductionDate <= endDate.Value);

            var products = await query.ToListAsync();
            return View(products);
        }
    }
}
