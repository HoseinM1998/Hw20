using AppDomainCore.Contract.Car;
using AppDomainCore.Contract.TechnicalExamination;
using AppDomainCore.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppEndPoint.Razor.Pages.TechnicalExamination
{
    public class CreateModel : PageModel
    {
        private readonly ICarAppService _carAppService;
        private readonly ITechnicalExaminationAppService _technicalExaminationAppService;

        public CreateModel(ICarAppService carAppService, ITechnicalExaminationAppService technicalExaminationAppService)
        {
            _carAppService = carAppService;
            _technicalExaminationAppService = technicalExaminationAppService;
        }

        [BindProperty]
        public AppDomainCore.Entities.TechnicalExamination TechnicalExamination { get; set; } = new();

        public List<AppDomainCore.Entities.Car> Cars { get; set; } = new();

        public void OnGet()
        {
            Cars = _carAppService.GetCars();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                OnGet(); 
                return Page();
            }

            var technicalExamination = new AppDomainCore.Entities.TechnicalExamination
            {
                FullName = TechnicalExamination.FullName,
                Phone = TechnicalExamination.Phone,
                NationalCode = TechnicalExamination.NationalCode,
                CarLicensePlate = TechnicalExamination.CarLicensePlate,
                YearProduction = TechnicalExamination.YearProduction,
                Address = TechnicalExamination.Address,
                CarId = TechnicalExamination.CarId,
                AppointmentDate = TechnicalExamination.AppointmentDate,
                RequestDate = DateTime.Now,
                Status = StatusTechnicalExaminationEnum.UnderReview
            };

            _technicalExaminationAppService.Add(technicalExamination);
            return RedirectToPage("/Index");
        }
    }
}
