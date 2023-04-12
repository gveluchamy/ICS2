using ICSLockers.Models;
using ICSLockers.Repository;
using ICSLockers.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
namespace ICSLockers.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AccountController> _logger;
<<<<<<< Updated upstream
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ILogger<AccountController> logger)
        {
            _roleManager = roleManager;
=======
        private readonly RoleManager<IdentityRole> _roleManager;       
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ILogger<AccountController> logger)
        {
            _roleManager = roleManager;            
>>>>>>> Stashed changes
            _userManager = userManager;
            _logger = logger;
        }

<<<<<<< Updated upstream
        private ApplicationUser? GetCurrentUser() {
            ClaimsPrincipal? currentUser = HttpContext.User;
            string? userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser? user = _userManager?.FindByIdAsync(userId).Result;
            return user;
        }
=======
        //private ApplicationUser? GetCurrentUser() {
        //    ClaimsPrincipal? currentUser = HttpContext.User;
        //    string? userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    ApplicationUser? user = _userManager?.FindByIdAsync(userId).Result;
        //    return user;
        //}
>>>>>>> Stashed changes

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View("Admin");
        }

        public IActionResult Index()
        {
            List<IdentityRole> model = new List<IdentityRole>();
            model = _roleManager.Roles.Select(r => new IdentityRole
            {
                Name = r.Name,
                Id = r.Id,
            }).ToList();
            ViewBag.ListRole = new SelectList(model, "Id", "Name");
            return View();
        }
<<<<<<< Updated upstream
=======
        public IActionResult Location()
        {
            return View();
        }
        public IActionResult AddLocation() 
        {            
            return View();
        }
>>>>>>> Stashed changes
    }
}
