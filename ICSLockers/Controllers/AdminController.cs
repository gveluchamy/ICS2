using ICSLockers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ICSLockers.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View("Admin");
        }
    }
}
