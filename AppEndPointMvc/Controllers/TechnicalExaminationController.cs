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

        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
              var technicalAndCar = new TechnicalAndCarDto
                {
                    ModelCars =await _carAppService.GetCars(cancellationToken) 
                };

                return View(technicalAndCar);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TechnicalAndCarDto technical, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                technical.ModelCars =await _carAppService.GetCars(cancellationToken);
                ModelState.AddModelError(string.Empty, "فیلدها را به درستی پر کنید.");
                return View(technical);
            }

            try
            {
                await _techAppService.Create(technical, cancellationToken);
                TempData["Success"] = "درخواست شما با موفقیت ثبت شد.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "خطایی رخ داد. لطفاً دوباره تلاش کنید.";
                return RedirectToAction("Create");
            }
        }

        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {

            try
            {
                var technical =await _techAppService.GetAll(cancellationToken);
                return View(technical);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "خطا در نمایش لیست معاینه فنی: " + ex.Message;
                return RedirectToAction("Create");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, StatusTechnicalExaminationEnum status, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
               await _techAppService.ChangeStatus(id, status, cancellationToken);
                TempData["Success"] = "وضعیت کاربر تغییر کرد";
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "فیلد هارو درست پرکنید");
                return RedirectToAction("List");

            }
   
        }

        public async Task<IActionResult> ListOldCar(CancellationToken cancellationToken)
        {
            try
            {
                var oldCAr =await _oldcarAppService.GetAllOldCars(cancellationToken);
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
