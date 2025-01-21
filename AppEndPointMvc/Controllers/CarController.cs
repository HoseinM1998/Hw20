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

        public IActionResult List()
        {
            var cars = _carAppService.GetCars(); 
            return View(cars); 
        }


        public IActionResult Create()
        {
            return View(new Car());
        }


        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                TempData["Success"] = " ادد شما با موفقیت ثبت شد";
                _carAppService.Create(car); 
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError(string.Empty,"فیلد هارو درست پرکنید");
                return View(car);
            }


        }


        public IActionResult Edit(int id)
        {
            var car = _carAppService.GetById(id); 
            if (car == null)
            {
                TempData["Error"] = "خطا در نمایش خودرو: ";
                return NotFound(); 
            }

            return View(car); 
        }

        [HttpPost]
        public IActionResult Edit(int id, Car car)
        {
            if (ModelState.IsValid)
            {
                var existingCar = _carAppService.GetById(id);
                if (existingCar == null)
                {
                    TempData["Error"] = "خطا دراویرایش خودرو: ";
                    return NotFound(); 
                }

                TempData["Success"] = " ادیت شما با موفقیت ثبت شد";
                _carAppService.Update(id, car);
                return RedirectToAction("List"); 
            }

            return View(car); 
        }


        public IActionResult CarDelete(int id)
        {
            var car = _carAppService.GetById(id); 
            if (car == null)
            {
                TempData["Error"] = "خطا در نمایش خودرو: ";
                return NotFound(); 
            }

            return View(car); 
        }

 
        [HttpPost]
        public IActionResult Delete(int id)
        {
            TempData["Success"] = "خودرو با موفقیت حذف شد";
            _carAppService.Delete(id); 
            return RedirectToAction("List"); 
        }

   
        public IActionResult About(int id)
        {
            var car = _carAppService.GetById(id); 
            if (car == null)
            {
                TempData["Error"] = "خطا در نمایش خودرو: ";
                return NotFound(); 
            }

            return View(car); 
        }
    }
}
