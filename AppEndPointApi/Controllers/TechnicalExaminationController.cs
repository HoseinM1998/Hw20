using AppDomainCore.Contract.Car;
using AppDomainCore.Contract.OldCar;
using AppDomainCore.Contract.TechnicalExamination;
using AppDomainCore.Dto;
using AppDomainCore.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace AppEndPointApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalExaminationController : ControllerBase
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

        [HttpGet("cars")]
        public IActionResult GetCars( )
        {
            var technicalAndCar = new TechnicalAndCarDto
            {
                ModelCars = _carAppService.GetCars()
            };

           return Ok(technicalAndCar);  
        }


        [HttpPost("create")]
        public IActionResult CreateTechnicalExamination([FromBody] TechnicalAndCarDto technical)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState); 
            _techAppService.Create(technical);
            return Ok("درخواست شما با موفقیت ثبت شد");
        }

        [HttpGet("list")]
        public IActionResult GetTechnicalExaminations()
        {
            try
            {
                var technicals = _techAppService.GetAll();
                if (technicals == null || !technicals.Any())
                {
                    return NotFound("هیچ آزمایش فنی یافت نشد.");
                }
                return Ok(technicals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "خطای داخلی سرور.");
            }
        }

        [HttpPost("changestatus/{id}")]
        public IActionResult ChangeStatus(int id, [FromBody] StatusTechnicalExaminationEnum status)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            _techAppService.ChangeStatus(id, status);
            return Ok("وضعیت با موفقیت تغییر کرد.");
        }

        [HttpGet("oldcars")]
        public IActionResult GetOldCars()
        {
            var oldCars = _oldcarAppService.GetAllOldCars();
            return Ok(oldCars);
        }
    }
}
