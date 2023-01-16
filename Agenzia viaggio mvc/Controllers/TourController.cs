using Microsoft.AspNetCore.Mvc;

namespace Agenzia_viaggio_mvc.Controllers
{
    public class TourController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details() { 
        return View();
        }
    }
}
