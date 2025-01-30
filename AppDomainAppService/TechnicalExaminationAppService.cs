using AppDomainCore.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.TechnicalExamination;
using AppDomainCore.Dto;
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

        public async Task Add(TechnicalExamination technicalExamination, CancellationToken cancellationToken)
        {
            try
            {

                await _techService.Add(technicalExamination, cancellationToken);

            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        public async Task Create(TechnicalAndCarDto technicalAndCar, CancellationToken cancellationToken)
        {
            try
            {
                var newTechnicalExamination = new TechnicalExamination
                {
                    FullName = technicalAndCar.FullName,
                    Phone = technicalAndCar.Phone,
                    NationalCode = technicalAndCar.NationalCode,
                    CarLicensePlate = technicalAndCar.CarLicensePlate,
                    YearProduction = technicalAndCar.YearProduction,
                    Address = technicalAndCar.Address,
                    CarId = technicalAndCar.CarId,
                    AppointmentDate = technicalAndCar.AppointmentDate,
                    RequestDate = DateTime.Now,
                    Status = StatusTechnicalExaminationEnum.UnderReview
                };
               await _techService.Add(newTechnicalExamination, cancellationToken);
            }
            catch (Exception eX)
            {
                throw new Exception("Error");
            }
        }

        //public void Create(TechnicalAndCarDto technicalAndCar)
        //{
        //    try
        //    {
        //        _techService.Create(technicalAndCar);
        //    }
        //    catch (Exception eX)
        //    {
        //        throw new Exception("Error");
        //    }
        //}

        public async Task<List<TechnicalExamination>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                return await _techService.GetAll(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error GetAll TechnicalExamination");
            }
        }

        public async Task<TechnicalExamination?> GetByCarLicensePlate(string carLicensePlate, CancellationToken cancellationToken)
        {
            try
            {
                return await _techService.GetByCarLicensePlate(carLicensePlate, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Get CarLicensePlate");
            }
        }

        public async Task ChangeStatus(int id, StatusTechnicalExaminationEnum status, CancellationToken cancellationToken)
        {
            try
            {
              await  _techService.ChangeStatus(id, status, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Change Status");
            }
        }

    }
}
