using Microsoft.AspNetCore.Mvc;

namespace AppEndPointMvc.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
