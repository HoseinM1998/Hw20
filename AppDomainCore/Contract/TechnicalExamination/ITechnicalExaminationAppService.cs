using AppDomainCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.TechnicalExamination
{
    public interface ITechnicalExaminationAppService
    {
        public void Add(Entities.TechnicalExamination technicalExamination);

        public List<Entities.TechnicalExamination> GetAll();
        public Entities.TechnicalExamination? GetByCarLicensePlate(int id,string carLicensePlate);
        public void ChangeStatus(int id,StatusTechnicalExaminationEnum status);
    }
}
