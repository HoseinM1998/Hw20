using AppDomainCore.Contract.TechnicalExamination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Entities;
using AppDomainCore.Enum;
using AppDomainCore.Contract.User;

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

            if ((Company == CompanyCarEnum.IranKhodro && (dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Wednesday || dayOfWeek == DayOfWeek.Friday)) ||
                (Company == CompanyCarEnum.Saipa && (dayOfWeek == DayOfWeek.Tuesday || dayOfWeek == DayOfWeek.Thursday)))
            {
                throw new Exception("Invalid day for the selected");
            }



            technicalExamination.Status = StatusTechnicalExaminationEnum.UnderReview;
            _repository.Add(technicalExamination);

        }

        public List<TechnicalExamination> GetAll()
        {
            throw new NotImplementedException();
        }

        public TechnicalExamination? GetByCarLicensePlate(string carLicensePlate)
        {
            throw new NotImplementedException();
        }

        public TechnicalExamination? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void ChangeStatus(int id, StatusTechnicalExaminationEnum status)
        {
            throw new NotImplementedException();
        }
    }
}
