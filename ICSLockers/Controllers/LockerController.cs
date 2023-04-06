using ICSLockers.Models;
using ICSLockers.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ICSLockers.Controllers
{
    public class LockerController : Controller
    {
        private readonly ILogger<LockerController> _logger;
        private readonly ILockerManager _lockerManager;

        public LockerController(ILogger<LockerController> logger, ILockerManager lockerManager)
        {
            _logger = logger;
            _lockerManager = lockerManager;
        }

        public IActionResult LocateUserLocker()
        {
            return View();
        }

        public IActionResult LockerUnits()
        {
            List<LockerUnits> lockerUnits = _lockerManager.GetLockerUnits();
            return View(lockerUnits);
        }

        public IActionResult UserReports()
        {
            return View();
        }

        public IActionResult UserLockerRecords()
        {
            return View();
        }
    }
}
