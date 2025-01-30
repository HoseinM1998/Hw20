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
        public async Task<IActionResult> GetAll([FromHeader] string? apikey, CancellationToken cancellationToken)
        {

            if (apikey == null)
                return BadRequest("وارد کردن رمز اجباری است");

            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی آی ندارید");

            var cars = await _carAppService.GetCars(cancellationToken);
            return Ok(cars);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get(int id, [FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            if (apikey == null)
                return BadRequest("وارد کردن رمز اجباری است");

            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی آی ندارید");

            var car = await _carAppService.GetById(id, cancellationToken);
            return Ok(car);
        }

        [HttpPost("add-car")]
        public async Task<IActionResult> Add([FromBody] Car car, [FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            if (apikey == null)
                return BadRequest("وارد کردن رمز اجباری است");

            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی آی ندارید");

            if (!ModelState.IsValid)
                return BadRequest("اطلاعات وارد شده صحیح نیست");
            await _carAppService.Create(car, cancellationToken);
            return Ok("ماشین اد شد");
        }

        [HttpPost("edit-car")]
        public async Task<IActionResult> Edit([FromBody] Car car, [FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            if (apikey == null)
                return BadRequest("وارد کردن رمز اجباری است");

            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی آی ندارید");


            if (!ModelState.IsValid)
                return BadRequest("اطلاعات وارد شده صحیح نیست");

            await _carAppService.Update(car.Id, car, cancellationToken);
            return Ok("اطلاعات ماشین بروز شد");
        }

        [HttpPost("delete-car")]
        public async Task<IActionResult> Delete([FromBody] int id, [FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            if (apikey == null)
                return BadRequest("وارد کردن رمز اجباری است");

            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی آی ندارید");

            await _carAppService.Delete(id, cancellationToken);
            return Ok("ماشین حذف شد");
        }
    }
}
