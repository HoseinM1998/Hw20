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
        Task Add(Entities.TechnicalExamination technicalExamination, CancellationToken cancellationToken);
        Task Create(TechnicalAndCarDto technicalAndCar, CancellationToken cancellationToken);

        Task<List<Entities.TechnicalExamination>> GetAll(CancellationToken cancellationToken);
        Task<Entities.TechnicalExamination?> GetByCarLicensePlate(string carLicensePlate, CancellationToken cancellationToken);
        Task ChangeStatus(int id,StatusTechnicalExaminationEnum status, CancellationToken cancellationToken);
       

    }
}
