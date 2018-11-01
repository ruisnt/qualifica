using Microsoft.AspNetCore.Mvc;

namespace Qualifica.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
