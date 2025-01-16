using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Enum;

namespace AppDomainCore.Contract.TechnicalExamination
{
    public interface ITechnicalExaminationRepository
    {
        public void Add(Entities.TechnicalExamination  technicalExamination);
        public List<Entities.TechnicalExamination> GetAll();
        public  Entities.TechnicalExamination? GetByCarLicensePlate(string carLicensePlate);
        public Entities.TechnicalExamination? GetById(int id);
        public void ChangeStatus(int id, StatusTechnicalExaminationEnum status);
        public int GetDailyCount(DateTime date, CompanyCarEnum company);

    }
}
