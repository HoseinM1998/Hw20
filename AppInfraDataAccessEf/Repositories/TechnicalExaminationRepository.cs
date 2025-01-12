using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.TechnicalExamination;
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
    }
}
