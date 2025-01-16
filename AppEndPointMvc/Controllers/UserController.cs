using AppDomainCore.Contract.OldCar;
using AppDomainCore.Contract.User;
using AppDomainCore.Entities;
using AppDomainService;
using AppInfraDbInMemory;
using Microsoft.AspNetCore.Mvc;

namespace AppEndPointMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            var user = _userAppService.Login(userName, password);
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            _userAppService.Register(user);
            return RedirectToAction("index","Home");
        }

        public IActionResult Logout()
        {
            InMemory.CurentUser = null;
            return RedirectToAction("index", "Home");

        }
    }
}
