using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ICSLockers.Models;
using Microsoft.EntityFrameworkCore;
using ICSLockers.Repository.IRepository;
using ICSLockers.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ICSLockers.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountManager _accountManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountManager accountManager, ILogger<AccountController> logger)
        {
            _accountManager = accountManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model, string returnUrl, string? page = null)
        {
           var (status, message) = await _accountManager.LoginAsync(model, page);
            return Json(new { success = status, Message = message, redirectUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            string userEmail = User.FindFirstValue(ClaimTypes.Email);
            await _accountManager.SignOutAsync(userEmail);           
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUser([FromBody] RegistrationModel model)
        {
            IdentityResult userCreationStatus = await _accountManager.CreateNewUserAsync(model);
            if (userCreationStatus.Succeeded)
            {
                _logger.LogDebug($"User {model.UserName} has been created successfully");
            }
            else
            {
                _logger.LogDebug($"User {model.UserName} has not been created.");
            }
            return RedirectToAction("Dashboard", "Admin");
        }
    }
}
