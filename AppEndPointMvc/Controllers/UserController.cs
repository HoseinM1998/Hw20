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
            TempData["Success"] = " وارد شدید ";
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _userAppService.Register(user);
                TempData["Success"] = " با موفقیت ثبت شد ";
                return RedirectToAction("index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "فیلد هارو درست پرکنید");
                return View(user);
            }
        }

        public IActionResult Logout()
        {
            InMemory.CurentUser = null;
            TempData["Success"] = " خارج شدید ";
            return RedirectToAction("index", "Home");

        }
    }
}
