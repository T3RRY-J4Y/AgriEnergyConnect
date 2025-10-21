using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;
using AgriEnergyConnect.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyConnect.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register() => View();

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Create Farmer profile linked to this user
                var context = HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();

                var farmer = new Farmer
                {
                    Name = model.Name,           // get Name from RegisterViewModel
                    Location = model.Location    // get Location from RegisterViewModel
                };

                // Save farmer to DB
                context.Farmers.Add(farmer);
                await context.SaveChangesAsync();

                // Link user to farmer
                user.FarmerId = farmer.Id;
                await _userManager.UpdateAsync(user);

                // Assign Farmer role
                await _userManager.AddToRoleAsync(user, "Farmer");

                // Sign in the user
                await _signInManager.SignInAsync(user, isPersistent: false);

                // Redirect to farmer dashboard
                return RedirectToAction("MyProducts", "Products");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }





        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login() => View();

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Get the logged-in user
                var user = await _userManager.FindByEmailAsync(model.Email);

                // Check roles and redirect accordingly
                if (await _userManager.IsInRoleAsync(user, "Employee"))
                {
                    return RedirectToAction("Index", "Farmers"); // Employee dashboard
                }
                else if (await _userManager.IsInRoleAsync(user, "Farmer"))
                {
                    return RedirectToAction("MyProducts", "Products"); // Farmer dashboard
                }

                // Default fallback
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }


        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
