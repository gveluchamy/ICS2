﻿using ICSLockers.Data;
using ICSLockers.Helpers;
using ICSLockers.Models;
using ICSLockers.Repository;
using ICSLockers.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
namespace ICSLockers.Controllers
{
    [Authorize(Roles ="Admin, Staff")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAdminRepository _adminRepository;
        private readonly ILogger<AccountController> _logger;
        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, IAdminRepository adminRepository, ILogger<AccountController> logger, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _adminRepository = adminRepository;
            _logger = logger;
            _context = context;
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
        public ActionResult Index(string role)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            List<IdentityRole> model = new List<IdentityRole>();
           
            if (userRole == "Staff")
            {
                model.Add(new IdentityRole { Name = "User" });
            }
            ViewBag.ListRole = model.ToList();
            ViewBag.Role=role;
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
            DivisionModel? division = _adminRepository.GetDivisionDetails(LocationId);
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
                var location = _adminRepository.GetDivisionDetails(division.DivisionId);
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
            var adminUsers = _userManager.GetUsersInRoleAsync("Admin").Result.ToList();
            var StaffUsers = _userManager.GetUsersInRoleAsync("Staff").Result.ToList();
            var Users = _userManager.GetUsersInRoleAsync("User").Result.ToList();
            ViewBag.AdminReports = adminUsers;
            ViewBag.StaffReports = StaffUsers;
            ViewBag.UserReports = Users;
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
        [HttpGet]
        public IActionResult UserProfile(int LockerId, int DivisionId, int LocationId)
            {
            // Fetch the locker details based on the provided ids
            var locker = _context.LockerUnits
                .Include(l => l.Division)
                    .ThenInclude(d => d.Location)
                .SingleOrDefault(l => l.LockerId == LockerId && l.DivisionId == DivisionId && l.Division.LocationId == LocationId);

            var locationName = _context.Locations.FirstOrDefault(l=>l.LocationId==LocationId).LocationName;

            if (locker == null)
            {
               return NotFound();
            }

            // Fetch the user details using the locker's UserId property
            var user = _context.Users.SingleOrDefault(u => u.LockerId.Equals(LockerId));


            if (user == null)
            {                
                return NotFound();
            }

            // Pass the locker and user details to the view
            var model = new 
            {
                Locker = locker,
                User = user,
                LocationName = locationName,
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult Guardian(int LockerId)
        {  
            var user = _context.Users.SingleOrDefault(u => u.LockerId.Equals(LockerId));
            if (user == null)
            {
                return BadRequest();
            }
            var model = user;
           
            return View(model);
        }
        [HttpPost]
        public IActionResult Guardian( [FromBody] ApplicationUser model)
        {
            var user = _context.Users.Where(x=>x.UserName == model.UserName).FirstOrDefault();
            if (user != null)
            {
                user.RelationShip=model.RelationShip;
                _context.Update(user);
                _context.SaveChanges();
            }
            //if (ModelState.IsValid)
            //{

            //}
            return View();
        }
        public IActionResult LockerDetails()
        {
            return View();
        }
    }
}
