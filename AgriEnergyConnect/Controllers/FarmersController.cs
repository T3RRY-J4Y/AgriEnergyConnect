using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgriEnergyConnect.Controllers
{
    [Authorize(Roles = "Employee")] // Only employees can access
    public class FarmersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Farmers
        public async Task<IActionResult> Index()
        {
            // Include products for each farmer
            var farmers = await _context.Farmers
                .Include(f => f.Products)
                .ToListAsync();
            return View(farmers);
        }

        // GET: /Farmers/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var farmer = await _context.Farmers
                .Include(f => f.Products)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (farmer == null)
                return NotFound();

            return View(farmer);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Farmer farmer)
        {
            if (!ModelState.IsValid)
                return View(farmer);

            _context.Farmers.Add(farmer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
