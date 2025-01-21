using AppDomainCore.Contract.Car;
using AppDomainCore.Contract.OldCar;
using AppDomainCore.Contract.TechnicalExamination;
using AppDomainCore.Dto;
using AppDomainCore.Entities;
using AppDomainCore.Enum;
using Microsoft.AspNetCore.Mvc;

namespace AppEndPointMvc.Controllers
{
    public class TechnicalExaminationController : Controller
    {
        private readonly ICarAppService _carAppService;
        private readonly ITechnicalExaminationAppService _techAppService;
        private readonly IOldCarAppService _oldcarAppService;


        public TechnicalExaminationController(ICarAppService carAppService, ITechnicalExaminationAppService techAppService, IOldCarAppService oldcarAppService)
        {
            _carAppService = carAppService;
            _techAppService = techAppService;
            _oldcarAppService = oldcarAppService;

        }

        public IActionResult Create()
        {
              var technicalAndCar = new TechnicalAndCarDto
                {
                    ModelCars = _carAppService.GetCars() 
                };

                return View(technicalAndCar);
        }

        [HttpPost]
        public IActionResult Create(TechnicalAndCarDto technical)
        {
            if (!ModelState.IsValid)
            {
                technical.ModelCars = _carAppService.GetCars();
                ModelState.AddModelError(string.Empty, "فیلدها را به درستی پر کنید.");
                return View(technical);
            }

            try
            {
                _techAppService.Create(technical);
                TempData["Success"] = "درخواست شما با موفقیت ثبت شد.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "خطایی رخ داد. لطفاً دوباره تلاش کنید.";
                return RedirectToAction("Create");
            }
        }

        public IActionResult List()
        {

            try
            {
                var technical = _techAppService.GetAll();
                return View(technical);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "خطا در نمایش لیست معاینه فنی: " + ex.Message;
                return RedirectToAction("Create");
            }
        }

        [HttpPost]
        public IActionResult ChangeStatus(int id, StatusTechnicalExaminationEnum status)
        {
            if (ModelState.IsValid)
            {
                _techAppService.ChangeStatus(id, status);
                TempData["Success"] = "وضعیت کاربر تغییر کرد";
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "فیلد هارو درست پرکنید");
                return RedirectToAction("List");

            }
   
        }

        public IActionResult ListOldCar()
        {
            try
            {
                var oldCAr = _oldcarAppService.GetAllOldCars();
                return View(oldCAr);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "خطا در نمایش لیست : " + ex.Message;
                return RedirectToAction("Index","Home");
            }
        }
    }
}
