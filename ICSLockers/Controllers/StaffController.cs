using Microsoft.AspNetCore.Mvc;

namespace ICSLockers.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult UserProfile()
        {
            return View(); 
        }
    }
}
