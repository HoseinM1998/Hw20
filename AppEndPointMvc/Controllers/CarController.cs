using AppDomainCore.Contract.Car;
using AppDomainCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppEndPointMvc.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarAppService _carAppService;

        public CarController(ICarAppService carAppService)
        {
            _carAppService = carAppService;
        }

        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {
            var cars =await _carAppService.GetCars(cancellationToken); 
            return View(cars); 
        }


        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            return View(new Car());
        }


        [HttpPost]
        public async Task<IActionResult> Create(Car car, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = " ادد شما با موفقیت ثبت شد";
               await _carAppService.Create(car, cancellationToken); 
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError(string.Empty,"فیلد هارو درست پرکنید");
                return View(car);
            }


        }


        public async Task<IActionResult> Edit(int id,CancellationToken cancellationToken)
        {
            var car =await _carAppService.GetById(id, cancellationToken); 
            if (car == null)
            {
                TempData["Error"] = "خطا در نمایش خودرو: ";
                return NotFound(); 
            }

            return View(car); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Car car, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var existingCar =await _carAppService.GetById(id, cancellationToken);
                if (existingCar == null)
                {
                    TempData["Error"] = "خطا دراویرایش خودرو: ";
                    return NotFound(); 
                }

                TempData["Success"] = " ادیت شما با موفقیت ثبت شد";
                await _carAppService.Update(id, car, cancellationToken);
                return RedirectToAction("List"); 
            }

            return View(car); 
        }


        public async Task<IActionResult> CarDelete(int id, CancellationToken cancellationToken)
        {
            var car =await _carAppService.GetById(id, cancellationToken); 
            if (car == null)
            {
                TempData["Error"] = "خطا در نمایش خودرو: ";
                return NotFound(); 
            }

            return View(car); 
        }

 
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            TempData["Success"] = "خودرو با موفقیت حذف شد";
            await _carAppService.Delete(id, cancellationToken); 
            return RedirectToAction("List"); 
        }

   
        public async Task<IActionResult> About(int id, CancellationToken cancellationToken)
        {
            var car =await _carAppService.GetById(id, cancellationToken); 
            if (car == null)
            {
                TempData["Error"] = "خطا در نمایش خودرو: ";
                return NotFound(); 
            }

            return View(car); 
        }
    }
}
