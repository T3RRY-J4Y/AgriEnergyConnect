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

        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> MyProducts()
        {
            var user = await _userManager.GetUserAsync(User);
            var products = await _context.Products
                .Where(p => p.FarmerId == user.FarmerId)
                .ToListAsync();
            return View(products);
        }

        [Authorize(Roles = "Farmer")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> Create(Product product)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.FarmerId == null) return Unauthorized();

            if (ModelState.IsValid)
            {
                product.FarmerId = user.FarmerId.Value;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MyProducts));
            }
            return View(product);
        }

        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> AllProducts(string? category, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category.Contains(category));

            if (startDate.HasValue)
                query = query.Where(p => p.ProductionDate >= startDate);

            if (endDate.HasValue)
                query = query.Where(p => p.ProductionDate <= endDate);

            return View(await query.ToListAsync());
        }
    }
}
