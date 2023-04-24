using ICSLockers.Helpers;
using ICSLockers.Models;
using ICSLockers.Repository;
using ICSLockers.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
namespace ICSLockers.Controllers
{
    [Authorize(Roles ="Admin, Staff")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAdminRepository _adminRepository;
        private readonly ILogger<AccountController> _logger;
        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, IAdminRepository adminRepository, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _adminRepository = adminRepository;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AdminLogin()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("~/Admin/Dashboard");
            }
            return View("Admin");
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            AdminDashboard dashboard = _adminRepository.GetDashBoardDetails();
            return View("AdminDashboard", dashboard);
        }

        public IActionResult Index()
        {
            List<IdentityRole> model = new();
            model = _roleManager.Roles.Select(r => new IdentityRole
            {
                Name = r.Name,
                Id = r.Id,
            }).ToList();
            ViewBag.ListRole = new SelectList(model, "Id", "Name");
            return View();
        }

        [HttpGet]
        public IActionResult Location()
        {
            List<LocationModel> locationModels = _adminRepository.GetAllLocations();
            return View(locationModels);
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] LocationModel location)
        {
            if (location != null)
            {
                var user = await _userManager.GetUserAsync(User);
                location.CreatedBy = user.Id;
                location.ModifiedBy = user.Id;
                var (Status, Message) = _adminRepository.AddLocation(location);
                string locationHtml = string.Empty;
                if (Status)
                {
                    locationHtml = await this.RenderViewAsync("~/Views/Admin/_LocationView.cshtml", location, true);
                    _logger.LogDebug(Message);
                }
                else
                {
                    _logger.LogDebug(Message);
                }
                return Json(new { success = Status, locationHtml, message = Message });
            }
            else
            {
                return Json(new { success = false, message = $"Location Model is null" });
            }
        }

        [HttpGet]
        public LocationModel? GetlocationDetails(int LocationId)
        {
            LocationModel? location = _adminRepository.GetLocationDetails(LocationId);
            GetDivisionDetails(LocationId);
            return location;
        }

        [HttpGet]
        public DivisionModel? GetDivisionDetails(int  LocationId)
        {
            DivisionModel? division = _adminRepository.GeDivisionDetails(LocationId);
            ViewBag.divisions=division;
            return division;
        }
        public IActionResult Division(int LocationId)
        {
            List<DivisionModel> divisionModel = _adminRepository.GetDivisionByLocationId(LocationId);
            return View(divisionModel);
        }

        [HttpPost]
        public bool AddDivisions([FromBody] LocationModel location)
        {
            try
            {
                _adminRepository.AddDivisionsByLocation(location);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<IActionResult> UpdateDivision([FromBody] DivisionModel division)
        {
            if (division != null)
            {
                var user = await _userManager.GetUserAsync(User);
                var location = _adminRepository.GeDivisionDetails(division.DivisionId);
                division.LocationId = location.LocationId;
                division.DivisionNo = location.DivisionNo;               
                division.CreatedBy = user.Id;
                division.ModifiedBy = user.Id;
                var (Status, Message) = _adminRepository.UpdateDivisionByDivisionID(division);
                string divisionHtml = string.Empty;
                if (Status)
                {
                    divisionHtml = await this.RenderViewAsync("~/Views/Admin/_DivisionView.cshtml", division, true);
                    _logger.LogDebug(Message);
                }
                else
                {
                    _logger.LogDebug(Message);
                }
                return Json(new { success = Status, divisionHtml, message = Message });
            }
            else
            {
                return Json(new { success = false, message = $"Location Model is null" });
            }
        }
                    
        public async Task<IActionResult> UpdateLocker([FromBody] LockerUnitModel lockerUnit)
        {
            if (lockerUnit != null)
            {
                var (Status, Message) = _adminRepository.UpdateLockerByDivisionId(lockerUnit);
                string lockerHtml = string.Empty;
                if (Status)
                {
                    lockerHtml = await this.RenderViewAsync("~/Views/Admin/_Units.cshtml", lockerUnit, true);
                    _logger.LogDebug(Message);
                }
                else
                {
                    _logger.LogDebug(Message);
                }
                return Json(new { success = Status, lockerHtml, message = Message });
            }
            else
            {
                return Json(new { success = false, message = $"Location Model is null" });
            }
        }

        public IActionResult LockerUnits(int DivisionId)
        {
            List<LockerUnitModel> lockerUnits = _adminRepository.GetLockerUnitsByDivisionId(DivisionId).ToList();
            if (lockerUnits == null)
            {
                return NotFound();
            }

            return View(lockerUnits);
        }

        public IActionResult UserReports()
        {
            UserReportsModel userReport = _adminRepository.UserReport();
            return View(userReport);
        }

        public IActionResult UserLockerRecords()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserLogs()
        {
            List<UserEvent> userEvents = _adminRepository.GetUserEventdetails();
            ViewBag.User = userEvents; 
            return View(userEvents);
        }

    }
}
