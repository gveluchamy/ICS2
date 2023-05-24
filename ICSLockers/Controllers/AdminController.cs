using Humanizer;
using ICSLockers.Data;
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
using System.Runtime.Serialization;
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
        public ActionResult Index(string role,int LockerId)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            List<IdentityRole> model = new List<IdentityRole>();
           
            if (userRole == "Staff")
            {
                model.Add(new IdentityRole { Name = "User" });
            }
            ViewBag.ListRole = model.ToList();
            ViewBag.Role=role;
            ViewBag.Locker=LockerId;
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
                Console.WriteLine(ex.Message);
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

            var location = _context.Locations.FirstOrDefault(l=>l.LocationId==LocationId);
            var locations= _context.Locations.ToList();
            if (locations != null)
            {
                 var locationItems = locations.Select(l => new SelectListItem
                {
                    Text = l.LocationName,
                    Value = l.LocationId.ToString()
                }).ToList();
                ViewBag.list=locationItems;
            }
            var division= _context.Divisions.ToList();
            if(division != null)
            {
                var divisionId = division.Select(l => new SelectListItem
                {                    
                    Value = l.DivisionId.ToString()
                }).ToList();
                ViewBag.divisionlist = divisionId;
            }
            var lockers = _context.LockerUnits.ToList().Where(l=>l.IsSpaceAvailable);
            //List<LockerUnitModel> units = new List<LockerUnitModel>();

            if (lockers != null)
            {
                var lockerId = lockers.Select(l => new SelectListItem
                {
                    Text =l.LockerNo.ToString(),
                    Value = l.LockerId.ToString()
                }).ToList();
                ViewBag.lockerslist = lockerId;
            }

            if (locker == null)
            {
               return NotFound();
            }

            // Fetch the user details using the locker's UserId property
            var user = _context.Users.FirstOrDefault(u => u.LockerId.Equals(LockerId));


            if (user == null)
            {                
                return NotFound();
            }

            // Pass the locker and user details to the view
            var model = new     
            {
                Locker = locker,
                User = user,
                Location = location               
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult Guardian(int LockerId)
        {  
            var user = _context.Users.FirstOrDefault(u => u.LockerId.Equals(LockerId));
            if (user == null)
            {
                return BadRequest();
            }
            var model = user;
           
            return View(model);
        }
        [HttpPost]
        public IActionResult Guardian( [FromBody] GuardianModel model )
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            var user = _context.Users.FirstOrDefault(x=>x.LockerId.Equals(model.LockerId)).Id;
            var locker = _context.Guardians.Any(x=>x.LockerId == model.LockerId);
            if (model != null&&model.GuardianName!=null)
            {
                model.UserId = user;
                model.CreatedBy = role;
                model.UpdatedBy = role;
                //user.RelationShip=model.RelationShip;
                _context.Guardians.Add(model);
                _context.SaveChanges();
            }            
            return Json(model);
        }
        [HttpGet]
        public IActionResult LockerDetails(int LockerId )
        {
            var locker = _context.LockerUnits.
                Include(l => l.Division)
                .ThenInclude(l=>l.Location)
                .SingleOrDefault(x => x.LockerId == LockerId);
            var user = _context.Users.FirstOrDefault(u => u.LockerId.Equals(LockerId));
            var relation =_context.Guardians.FirstOrDefault(g=>g.LockerId.Equals(LockerId)).RelationShip;
            var location = _context.Locations.FirstOrDefault(l => l.LocationId == user.LocationId);
            if (user == null)
            {
                return NotFound();
            }
            if(locker == null)
            {
                return BadRequest();
            }
            var model = new
            {
                Locker=locker,
                User=user,
                Location=location,
                RelationShip = relation

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult RemoveAllItems(int LockerId)
        {
            // Find the locker units with the specified locker ID
            var lockerUnits = _context.LockerUnits.FirstOrDefault(l => l.LockerId == LockerId);

            // If the locker units exist, remove all items
            if (lockerUnits != null)
            {
                lockerUnits.Item1 = string.Empty;
                lockerUnits.Item2 = string.Empty;
                lockerUnits.Item3 = string.Empty;
                lockerUnits.Item4 = string.Empty;
                lockerUnits.Item5 = string.Empty;

                // Update the locker units and save changes to the database
                _context.Update(lockerUnits);
                _context.SaveChanges();

                return Ok("All items have been removed from the locker.");
            }

            return NotFound();

        }
        [HttpGet]
        public IActionResult UpdateLocker( int LockerId,int DivisionId, int LocationId)
        {
            var locker = _context.LockerUnits
                .Include(l=>l.Division)
                .ThenInclude(l=>l.Location).FirstOrDefault(l=>l.LockerId==LockerId&& l.DivisionId==DivisionId&&l.Division.LocationId== LocationId);
             var locationName = _context.Locations.FirstOrDefault(l => l.LocationId == LocationId).LocationName;
            if (locker == null)
            {
                return NotFound();
            }
            var user = _context.Users.FirstOrDefault(x=>x.LockerId==LockerId);
            if (user == null)
            {
                return BadRequest();
            }
            var model = new
            {
                Locker = locker,
                LocationName = locationName,
                User = user,
            };
              return View(model);
        }
        [HttpPost]
        public IActionResult UpdateItems([FromBody]LockerUnitModel items)
        {
            var locker = _context.LockerUnits.FirstOrDefault(x=>x.LockerId== items.LockerId);
            var message = "Success";
            if (locker != null&&items!=null)
            {
                locker.Item1 = items.Item1;
                locker.Item2 = items.Item2;
                locker.Item3 = items.Item3;
                locker.Item4 = items.Item4;
                locker.Item5 = items.Item5;
                _context.Update(locker);
                _context.SaveChanges();
                var division = _context.Divisions.FirstOrDefault(x=>x.DivisionId==items.DivisionId);
                if(division != null&&division.IsLockersAvailable)
                {
                    division.UsedLockers = division.UsedLockers + 1;
                }
            }

            return Json(new { success = locker, Message = message });
        }
    }
}
