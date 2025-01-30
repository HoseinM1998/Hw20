using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Dto;
using AppDomainCore.Enum;

namespace AppDomainCore.Contract.TechnicalExamination
{
    public interface ITechnicalExaminationRepository
    {
        Task Add(Entities.TechnicalExamination  technicalExamination, CancellationToken cancellationToken);
        Task Create(TechnicalAndCarDto technicalAndCar, CancellationToken cancellationToken);

        Task<List<Entities.TechnicalExamination>> GetAll( CancellationToken cancellationToken);
        Task<Entities.TechnicalExamination?> GetByCarLicensePlate(string carLicensePlate, CancellationToken cancellationToken);
        Task<Entities.TechnicalExamination?> GetById(int id, CancellationToken cancellationToken);
        Task ChangeStatus(int id, StatusTechnicalExaminationEnum status, CancellationToken cancellationToken);
        Task<int> GetDailyCount(DateTime date, CompanyCarEnum company, CancellationToken cancellationToken);

    }
}
