using AppDomainCore.Contract.OldCar;
using AppDomainCore.Contract.User;
using AppDomainCore.Entities;
using AppDomainService;
using AppInfraDbInMemory;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using AppDomainCore.Dto;

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
        public async Task<IActionResult> Login(string userName,string password,CancellationToken cancellationToken)
        {
            var User = await _userAppService.Login(userName,password);

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
            return View(new UserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto user,CancellationToken cancellationToken)
        {

           await _userAppService.Register(user, cancellationToken);
            if (user != null)
            {
                TempData["Success"] = " با موفقیت ثبت شد ";
                return RedirectToAction("index", "Home");
            }

            ModelState.AddModelError(string.Empty, "فیلد هارو درست پرکنید");
            return View(user);

        }

        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("ApiKey");
            TempData["Success"] = " خارج شدید ";
            return RedirectToAction("index", "Home");

        }
    }
}
