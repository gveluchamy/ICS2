using ICSLockers.Models;
using ICSLockers.Repository;
using ICSLockers.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICSLockers.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILockerManager _lockerManager;

        public AdminController(RoleManager<IdentityRole> roleManager, ILockerManager lockerManager, ILogger<AccountController> logger)
        {
            _roleManager = roleManager;
            _lockerManager = lockerManager;
            _logger = logger;
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
            List<LockerUnits> lockerUnits = _lockerManager.GetLockerUnits();
            return View(lockerUnits);
        }

        public async Task<IActionResult> CreateNewLocker([FromBody] LockerUnits model)
        {
            //model.CreatedBy = 
            var (Status, Message) = _lockerManager.CreateNewLocker(model);
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

        public IActionResult LockerDetails()
        {
            List<LockerUnits> lockerUnits = _lockerManager.GetLockerUnits();
            return View(lockerUnits);
                      
        }
    }
}
