using Microsoft.AspNetCore.Mvc;

namespace PROYECTO_FLK.BACKEND.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
