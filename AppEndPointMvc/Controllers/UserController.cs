using AppDomainCore.Contract.OldCar;
using AppDomainCore.Contract.User;
using AppDomainCore.Entities;
using AppDomainService;
using AppInfraDbInMemory;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace AppEndPointMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user,CancellationToken cancellationToken)
        {
            var User =await _userAppService.Login(user.UserName, user.Password, cancellationToken);

            if (User != null)
            {
                TempData["Success"] = "وارد شدید";
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "نام کاربری یا رمز عبور نادرست است");

            return View();
        }

        public async Task<IActionResult> Register()
        {
            return View(new User());
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user,CancellationToken cancellationToken)
        {

           await _userAppService.Register(user, cancellationToken);
            if (User != null)
            {
                TempData["Success"] = " با موفقیت ثبت شد ";
                return RedirectToAction("index", "Home");
            }

            ModelState.AddModelError(string.Empty, "فیلد هارو درست پرکنید");
            return View(user);

        }

        public IActionResult Logout()
        {
            InMemory.CurentUser = null;
            TempData["Success"] = " خارج شدید ";
            return RedirectToAction("index", "Home");

        }
    }
}
