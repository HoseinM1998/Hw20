using AppDomainCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Dto;

namespace AppDomainCore.Contract.TechnicalExamination
{
    public interface ITechnicalExaminationAppService
    {
        public void Add(Entities.TechnicalExamination technicalExamination);
        public void Create(TechnicalAndCarDto technicalAndCar);

        public List<Entities.TechnicalExamination> GetAll();
        public Entities.TechnicalExamination? GetByCarLicensePlate(string carLicensePlate);
        public void ChangeStatus(int id,StatusTechnicalExaminationEnum status);
       

    }
}
