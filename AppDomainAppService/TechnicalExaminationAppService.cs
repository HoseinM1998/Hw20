using AppDomainCore.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.TechnicalExamination;
using AppDomainCore.Entities;
using AppDomainCore.Enum;

namespace AppDomainAppService
{
    public class TechnicalExaminationAppService : ITechnicalExaminationAppService
    {
        private readonly ITechnicalExaminationService _techService;

        public TechnicalExaminationAppService(ITechnicalExaminationService techService)
        {
            _techService = techService;
        }

        public void Add(TechnicalExamination technicalExamination)
        {
            try
            {
                if (technicalExamination.YearProduction.Year < DateTime.Now.Year - 5)
                {
                    _techService.AddOldCAr(technicalExamination);
                }
                else
                {
                    _techService.Add(technicalExamination);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        public List<TechnicalExamination> GetAll()
        {
            try
            {
                return _techService.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error GetAll TechnicalExamination");
            }
        }

        public TechnicalExamination? GetByCarLicensePlate(string carLicensePlate)
        {
            try
            {
                return _techService.GetByCarLicensePlate(carLicensePlate);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Get CarLicensePlate");
            }
        }

        public void ChangeStatus(int id, StatusTechnicalExaminationEnum status)
        {
            try
            {
                _techService.ChangeStatus(id,status);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Change Status");
            }
        }

        public List<TechnicalExamination> GetAllOldCar()
        {
            try
            {
                return _techService.GetAllOldCar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error GetAll TechnicalExamination");
            }
        }
    }
}
