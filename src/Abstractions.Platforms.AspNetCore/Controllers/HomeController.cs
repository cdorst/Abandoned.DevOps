using Microsoft.AspNetCore.Mvc;

namespace DevOps.Abstractions.Platforms.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
