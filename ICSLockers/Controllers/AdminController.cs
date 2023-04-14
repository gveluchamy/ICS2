﻿using ICSLockers.Models;
using ICSLockers.Repository;
using ICSLockers.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
namespace ICSLockers.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAdminRepository _adminRepository;
        private readonly ILogger<AccountController> _logger;
        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IAdminRepository adminRepository, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _adminRepository = adminRepository;
            _logger = logger;
        }

        //private ApplicationUser? GetCurrentUser() {
        //    ClaimsPrincipal? currentUser = HttpContext.User;
        //    string? userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    ApplicationUser? user = _userManager?.FindByIdAsync(userId).Result;
        //    return user;
        //}

        [AllowAnonymous]
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View("Admin");
        }

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
        public IActionResult Division(int LocationId)
        {
            List<DivisionModel> divisionModel = _adminRepository.GetDivisionByLocationId(LocationId);
            return View(divisionModel);
        }

        public async Task<IActionResult>UpdateDivision(DivisionModel division)
        {
            if (division != null)
            {
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
          
       

        public IActionResult LockerUnits(int DivisionId)
        {
            List<LockerUnitModel> lockerUnits= _adminRepository.GetLockerUnitsByDivisionId(DivisionId);
            if (lockerUnits == null)
            {
                return NotFound();
            }

            return View(lockerUnits);
        }
    }
}
