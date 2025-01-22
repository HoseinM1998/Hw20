using AppDomainCore.Contract.TechnicalExamination;

using AppDomainCore.Enum;
using AppDomainCore.Contract.OldCar;
using AppDomainCore.Contract.Car;
using AppDomainCore.Dto;
using AppDomainCore.Entities;
using AppDomainCore.Entities.Config;
using Microsoft.Extensions.Configuration;
namespace AppDomainService
{
    public class TechnicalExaminationService : ITechnicalExaminationService
    {

        private readonly ITechnicalExaminationRepository _repository;
        private readonly IOldCarRepository _repositoryOldCAr;
        private readonly ICarRepository _repositoryCar;
        private readonly IConfiguration _configuration;
        private readonly SiteSetting _siteSetting;



        public TechnicalExaminationService(ITechnicalExaminationRepository repository , IOldCarRepository repositoryOldCAr, ICarRepository repositoryCar,IConfiguration configuration, SiteSetting siteSetting)
        {
            _repository = repository;
            _repositoryOldCAr = repositoryOldCAr;
            _repositoryCar = repositoryCar;
            _configuration = configuration;
            _siteSetting = siteSetting;

        }

       

        public void Add(TechnicalExamination technicalExamination)
        {
            if (technicalExamination == null)
            {
                throw new Exception("User Not Found");
            }
            if(technicalExamination.AppointmentDate<DateTime.Now)
            {
                throw new Exception("The Date Must Be Up To Date");

            }

            if (technicalExamination.YearProduction.Year < DateTime.Now.Year - 5)
            {
                OldCar oldCar = new OldCar
                {
                    FullName = technicalExamination.FullName,
                    Phone = technicalExamination.Phone,
                    NationalCode = technicalExamination.NationalCode,
                    CarLicensePlate = technicalExamination.CarLicensePlate,
                    YearProduction = technicalExamination.YearProduction,
                    Address = technicalExamination.Address,
                    CarId = technicalExamination.CarId,
                    RequestDate = DateTime.Now
                };

                _repositoryOldCAr.AddOldCAr(oldCar);
                return;
            }
            var dayOfWeek = technicalExamination.AppointmentDate.DayOfWeek;
            var Enum = _repositoryCar.GetById(technicalExamination.CarId);
            var Company = Enum.CarEnum;

            if ((Company == CompanyCarEnum.IranKhodro && (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Wednesday )) ||
                (Company == CompanyCarEnum.Saipa && (dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Tuesday || dayOfWeek == DayOfWeek.Thursday)))
            {
                throw new Exception("Invalid day for the selected");
            }

            var car = _repository.GetByCarLicensePlate(technicalExamination.CarLicensePlate);
           if (car != null)
            {
                if (car.AppointmentDate.AddYears(1) > DateTime.Now)
                {
                    throw new Exception("You Can Only Do It Once A Year");

                }
                throw new Exception("Existing Car");
            }
            var saipa = int.Parse(_configuration.GetSection("LimitData:Saipa").Value);
            var iranKhodro = int.Parse(_configuration.GetSection("LimitData:IranKhodro").Value);

            var dailyCount = _repository.GetDailyCount(technicalExamination.AppointmentDate, Company);

            if ((Company == CompanyCarEnum.Saipa && dailyCount >= saipa) ||
                (Company == CompanyCarEnum.IranKhodro && dailyCount >= iranKhodro))
            {
                throw new Exception("Capacity Is Full Today, Choose Another Day");
            }


            //var saipa = int.Parse(_siteSetting.LimitData.Saipa);
            //var iranKhodro = int.Parse(_siteSetting.LimitData.IranKhodro);

            //var dailyCount = _repository.GetDailyCount(technicalExamination.AppointmentDate, Company);

            //if ((Company == CompanyCarEnum.Saipa && dailyCount >= saipa) ||
            //    (Company == CompanyCarEnum.IranKhodro && dailyCount >= iranKhodro))
            //{
            //    throw new Exception("Capacity Is Full Today, Choose Another Day");
            //}





            technicalExamination.RequestDate = DateTime.Now;
            technicalExamination.Status = StatusTechnicalExaminationEnum.UnderReview;
            _repository.Add(technicalExamination);

        }

        public List<TechnicalExamination> GetAll()
        {
            return _repository.GetAll();
        }

        public void Create(TechnicalAndCarDto technicalAndCar)
        {
            throw new NotImplementedException();
        }


        public TechnicalExamination? GetByCarLicensePlate(string carLicensePlate)
        {
            var carLicensePlat = _repository.GetByCarLicensePlate(carLicensePlate);
            if (carLicensePlat == null)
            {
                throw new Exception("carLicensePlate Not Found");
            }

            return carLicensePlat;
        }

        public TechnicalExamination? GetById(int id)
        {
            var technicalExamination = _repository.GetById(id);
            if (technicalExamination == null)
            {
                throw new Exception("technicalExamination Not Found");
            }

            return technicalExamination;
        }

        public void ChangeStatus(int id, StatusTechnicalExaminationEnum status)
        {
            var tech = _repository.GetById(id);
            if(tech == null)
            {
                throw new Exception("technicalExamination Not Found");
            }
            _repository.ChangeStatus(id,status);

        }

    }
}
