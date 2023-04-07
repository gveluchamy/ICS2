using ICSLockers.Models;
using ICSLockers.Repository;
using ICSLockers.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ICSLockers.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILockerManager _lockerManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, ILockerManager lockerManager, UserManager<ApplicationUser> userManager, ILogger<AccountController> logger)
        {
            _roleManager = roleManager;
            _lockerManager = lockerManager;
            _userManager = userManager;
            _logger = logger;
        }

        private ApplicationUser? GetCurrentUser() {
            ClaimsPrincipal? currentUser = HttpContext.User;
            string? userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser? user = _userManager?.FindByIdAsync(userId).Result;
            return user;
        }

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

        public IActionResult LockerUnits()
        {
            if (GetCurrentUser() == null)
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            List<LockerUnits> lockerUnits = _lockerManager.GetLockerUnits();
            return View(lockerUnits);
        }

        public async Task<IActionResult> CreateNewLocker([FromBody] LockerUnits model)
        {           
            var (Status, Message) = _lockerManager.CreateNewLockerUnit(model, GetCurrentUser());
            string unitHTML = string.Empty;
            if (Status)
            {
                unitHTML = await this.RenderViewAsync("~/Views/Admin/_Units.cshtml", model, true);
                _logger.LogDebug(Message); 
            }
            else
            {
                _logger.LogDebug(Message);
            }
            return Json(new { success = Status, unitHTML, message = Message });
        }

        public IActionResult LockerDetails(int lockerUnitId)
        {
            if(GetCurrentUser() == null)
            {
                return RedirectToAction("AdminLogin", "Admin");                
            }
            List<LockerDetailsModel> lockerDetailsList = _lockerManager.GetLockersByLockerUnit(lockerUnitId);
            return View(lockerDetailsList);                      
        }
    }
}
