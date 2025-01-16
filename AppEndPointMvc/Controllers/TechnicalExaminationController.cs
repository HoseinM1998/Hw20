using AppDomainCore.Contract.Car;
using AppDomainCore.Contract.OldCar;
using AppDomainCore.Contract.TechnicalExamination;
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
            try
            {
                var cars = _carAppService.GetCars();

       
                return View(cars);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "خطا در نمایش لیست خودروها: " + ex.Message;
                return RedirectToAction("List");
            }
        }

        [HttpPost]
        public IActionResult Create(TechnicalExamination technical)
        {
            try
            {
                _techAppService.Add(technical);
                TempData["Success"] = "درخواست شما با موفقیت ثبت شد";
                return RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "خطا در ثبت معاینه فنی: " + ex.Message;
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
            try
            {
                _techAppService.ChangeStatus(id, status);
                TempData["Success"] = "وضعیت کاربر تغییر کرد";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "خطا در تغییر وضعیت : " + ex.Message;
            }
            return RedirectToAction("List");
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
                return RedirectToAction("Create");
            }
        }
    }
}
