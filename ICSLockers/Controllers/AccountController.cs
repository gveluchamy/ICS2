using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ICSLockers.Models;
using Microsoft.EntityFrameworkCore;
using ICSLockers.Repository.IRepository;
using ICSLockers.Helpers;

namespace ICSLockers.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountManager _accountManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger, UserManager<ApplicationUser> userManager, IAccountManager accountManager)
        {
            _signInManager = signInManager;
            _logger = logger;   
            _userManager = userManager;
            _accountManager = accountManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model, string returnUrl)
        {
            ApplicationUser? user = _accountManager.FindUserByPassword(model.Password);

            if (user != null) 
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    _logger.LogDebug($"The user {model.Email} is about to signed in.");
                    return Redirect(returnUrl);
                }
                

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

        [HttpPost]
        [Route("api/user")]
        public async Task<IActionResult> CreateNewUser([FromBody] ApplicationUser model)
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
            return View();
        }

    }
}
