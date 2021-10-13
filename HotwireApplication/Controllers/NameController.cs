using Microsoft.AspNetCore.Mvc;

namespace HotwireApplication.Controllers
{
    public class NameController : Controller
    {
        // GET
        public IActionResult New()
        {
            return View();
        }
    }
}