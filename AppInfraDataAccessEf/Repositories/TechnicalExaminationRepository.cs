using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.TechnicalExamination;
using AppDomainCore.Dto;
using AppDomainCore.Entities;
using AppDomainCore.Enum;
using AppInfraDbSqlServer;
using Microsoft.EntityFrameworkCore;

namespace AppInfraDataAccessEf.Repositories
{
    public class TechnicalExaminationRepository : ITechnicalExaminationRepository
    {
        private readonly AppDbContext _context;

        public TechnicalExaminationRepository(AppDbContext context)
        {
            _context = context;
        }


        public void Add(TechnicalExamination technicalExamination)
        {
            _context.TechnicalExaminations.Add(technicalExamination);
            _context.SaveChanges();
        }

        public void Create(TechnicalAndCarDto technicalAndCar)
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
            _context.TechnicalExaminations.Add(newTechnicalExamination);
            _context.SaveChanges();
        }
        

        public List<TechnicalExamination> GetAll()
        {
            return _context.TechnicalExaminations.Include(C => C.Car).AsNoTracking().ToList();

        }

        public TechnicalExamination? GetByCarLicensePlate(string carLicensePlate)
        {
            return _context.TechnicalExaminations.AsNoTracking().FirstOrDefault(u => u.CarLicensePlate == carLicensePlate);

        }

        public TechnicalExamination? GetById(int id)
        {
            return _context.TechnicalExaminations.AsNoTracking().FirstOrDefault(u => u.Id == id);

        }

        public void ChangeStatus(int id,StatusTechnicalExaminationEnum status)
        {
            var changestatus = _context.TechnicalExaminations.Find(id);
            changestatus.Status = status;
            _context.SaveChanges();
            
        }

        public int GetDailyCount(DateTime date, CompanyCarEnum company)
        {
            return _context.TechnicalExaminations
                .Where(t => t.AppointmentDate.Date == date.Date && t.Car.CarEnum == company)
                .Count();
        }
    }
}
