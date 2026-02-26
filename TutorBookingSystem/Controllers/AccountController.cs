using Microsoft.AspNetCore.Mvc;

namespace TutorBookingSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
