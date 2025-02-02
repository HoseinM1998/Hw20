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
        public async Task<IActionResult> GetCars(CancellationToken cancellationToken)
        {
            var technicalAndCar = new TechnicalAndCarDto
            {
                ModelCars = await _carAppService.GetCars(cancellationToken)
            };

            return Ok(technicalAndCar);
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateTechnicalExamination([FromBody] TechnicalAndCarDto technical, CancellationToken cancellationToken)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _techAppService.Create(technical, cancellationToken);
            return Ok("درخواست شما با موفقیت ثبت شد");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetTechnicalExaminations(CancellationToken cancellationToken)
        {
            try
            {
                var technicals = await _techAppService.GetAll(cancellationToken);
                if (technicals == null || !technicals.Any())
                {
                    return NotFound("هیچ معاینه فنی یافت نشد.");
                }
                return Ok(technicals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "خطای داخلی سرور.");
            }
        }

        [HttpPost("changestatus/{id}")]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] StatusTechnicalExaminationEnum status, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _techAppService.ChangeStatus(id, status, cancellationToken);
            return Ok("وضعیت با موفقیت تغییر کرد.");
        }

        [HttpGet("oldcars")]
        public async Task<IActionResult> GetOldCars(CancellationToken cancellationToken)
        {
            var oldCars = await _oldcarAppService.GetAllOldCars(cancellationToken);
            return Ok(oldCars);
        }
    }
}
