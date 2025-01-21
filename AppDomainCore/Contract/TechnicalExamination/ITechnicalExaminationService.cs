using AppDomainCore.Dto;
using AppDomainCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.TechnicalExamination
{
    public interface ITechnicalExaminationService
    {
        public void Add(Entities.TechnicalExamination technicalExamination);
        public List<Entities.TechnicalExamination> GetAll();
        public void Create(TechnicalAndCarDto technicalAndCar);

        public Entities.TechnicalExamination? GetByCarLicensePlate(string carLicensePlate);
        public Entities.TechnicalExamination? GetById(int id);
        public void ChangeStatus(int id, StatusTechnicalExaminationEnum status);

    }
}
