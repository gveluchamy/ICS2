using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ICSLockers.Controllers
{
    [Authorize(Roles ="Staff")]
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [AllowAnonymous]
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
