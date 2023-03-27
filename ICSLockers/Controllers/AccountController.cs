using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ICSLockers.Models;
using Microsoft.EntityFrameworkCore;

namespace ICSLockers.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model, string returnUrl)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                _logger.LogDebug($"The user {model.Email} is about to signed in.");
                return Redirect(returnUrl);
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            _logger.LogDebug("The user is about to signout...");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
