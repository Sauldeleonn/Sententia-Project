using Microsoft.AspNetCore.Mvc;

namespace API_Sententia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
