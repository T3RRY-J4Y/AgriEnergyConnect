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
                product.FarmerId = user.FarmerId.Value;
                if (product.ProductionDate == default)
                    product.ProductionDate = DateTime.UtcNow;

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MyProducts));
            }

            return View(product);
        }

        // Farmer dashboard: show edit form
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && p.FarmerId == user.FarmerId);

            if (product == null) return NotFound();

            return View(product);
        }

        // Farmer dashboard: save edited product
        [HttpPost]
        [Authorize(Roles = "Farmer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            var user = await _userManager.GetUserAsync(User);

            if (id != product.Id || product.FarmerId != user.FarmerId)
                return NotFound();

            if (!ModelState.IsValid) return View(product);

            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id)) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(MyProducts));
        }

        // Farmer dashboard: confirm delete
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            var product = await _context.Products
                .Include(p => p.Farmer)
                .FirstOrDefaultAsync(p => p.Id == id && p.FarmerId == user.FarmerId);

            if (product == null) return NotFound();

            return View(product);
        }

        // Farmer dashboard: perform delete
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Farmer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && p.FarmerId == user.FarmerId);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyProducts));
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

        private bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.Id == id);
        }
    }
}
