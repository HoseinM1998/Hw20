using AppDomainCore.Contract.Car;
using AppDomainCore.Entities;
using AppDomainCore.Entities.Config;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppEndPointApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarAppService _carAppService;
        private readonly string ApiKey;

        public CarController(ICarAppService carAppService, SiteSetting siteSetting)
        {
            _carAppService = carAppService;
            ApiKey = siteSetting.ApiKey;
        }

        private bool ValidateApiKey(string? apikey)
        {
            return apikey == ApiKey;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll([FromHeader] string? apikey)
        {

            if (apikey == null)
                return BadRequest("وارد کردن رمز اجباری است");

            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی آی ندارید");

            var cars = _carAppService.GetCars();
            return Ok(cars);
        }

        [HttpGet("[action]")]
        public IActionResult Get(int id, [FromHeader] string? apikey)
        {
            if (apikey == null)
                return BadRequest("وارد کردن رمز اجباری است");

            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی آی ندارید");

            var car = _carAppService.GetById(id);
            return Ok(car);
        }

        [HttpPost("add-car")]
        public IActionResult Add([FromBody] Car car, [FromHeader] string? apikey)
        {
            if (apikey == null)
                return BadRequest("وارد کردن رمز اجباری است");

            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی آی ندارید");

            if (!ModelState.IsValid)
                return BadRequest("اطلاعات وارد شده صحیح نیست");
            _carAppService.Create(car);
            return Ok("ماشین اد شد");
        }

        [HttpPost("edit-car")]
        public IActionResult Edit([FromBody] Car car, [FromHeader] string? apikey)
        {
            if (apikey == null)
                return BadRequest("وارد کردن رمز اجباری است");

            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی آی ندارید");


            if (!ModelState.IsValid)
                return BadRequest("اطلاعات وارد شده صحیح نیست");

            _carAppService.Update(car.Id, car);
            return Ok("اطلاعات ماشین بروز شد");
        }

        [HttpPost("delete-car")]
        public IActionResult Delete([FromBody] int id, [FromHeader] string? apikey )
        {
            if (apikey == null)
                return BadRequest("وارد کردن رمز اجباری است");

            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی آی ندارید");

            _carAppService.Delete(id);
            return Ok("ماشین حذف شد");
        }
    }
}
