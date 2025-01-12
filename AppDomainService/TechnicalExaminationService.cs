using AppDomainCore.Contract.TechnicalExamination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Entities;
using AppDomainCore.Enum;
using AppDomainCore.Contract.User;
using Microsoft.EntityFrameworkCore;

namespace AppDomainService
{
    public class TechnicalExaminationService : ITechnicalExaminationService
    {

        private readonly ITechnicalExaminationRepository _repository;

        public TechnicalExaminationService(ITechnicalExaminationRepository repository)
        {
            _repository = repository;
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
            var dayOfWeek = technicalExamination.AppointmentDate.DayOfWeek;
            var Company = technicalExamination.Car.CarEnum;

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
            }


            if (technicalExamination.YearProduction.Year < DateTime.Now.Year - 5)
            {
                technicalExamination.Status = StatusTechnicalExaminationEnum.UnderReview;
                _repository.AddOldCAr(technicalExamination);
                return;
            }


            technicalExamination.Status = StatusTechnicalExaminationEnum.UnderReview;
            _repository.Add(technicalExamination);

        }

        public List<TechnicalExamination> GetAll()
        {
            return _repository.GetAll();
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

        public List<TechnicalExamination> GetAllOldCar()
        {
            return _repository.GetAllOldCar();
        }

        public void AddOldCAr(TechnicalExamination technicalExamination)
        {
            _repository.AddOldCAr(technicalExamination);
        }
    }
}
