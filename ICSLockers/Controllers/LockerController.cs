using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ICSLockers.Controllers
{
    public class LockerController : Controller
    {
        private readonly ILogger<LockerController> _logger;

        public LockerController(ILogger<LockerController> logger)
        {
            _logger = logger;
        }

        public IActionResult LocateUserLocker()
        {
            return View();
        }

        public IActionResult LockerUnits()
        {
            return View();
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
