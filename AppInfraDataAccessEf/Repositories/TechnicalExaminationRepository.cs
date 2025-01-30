using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


        public async Task Add(TechnicalExamination technicalExamination, CancellationToken cancellationToken)
        {
            await _context.TechnicalExaminations.AddAsync(technicalExamination, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Create(TechnicalAndCarDto technicalAndCar,CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TechnicalExamination>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.TechnicalExaminations.Include(C => C.Car).AsNoTracking().ToListAsync();

        }

        public async Task<TechnicalExamination?> GetByCarLicensePlate(string carLicensePlate,CancellationToken cancellationToken)
        {
            return await _context.TechnicalExaminations.AsNoTracking().FirstOrDefaultAsync(u => u.CarLicensePlate == carLicensePlate, cancellationToken);
        }

        public async Task<TechnicalExamination?> GetById(int id,CancellationToken cancellationToken)
        {
            return await _context.TechnicalExaminations.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        }

        public async Task ChangeStatus(int id, StatusTechnicalExaminationEnum status,CancellationToken cancellationToken)
        {
            var changestatus =await _context.TechnicalExaminations.FindAsync(id, cancellationToken);
            changestatus.Status = status;
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task<int> GetDailyCount(DateTime date, CompanyCarEnum company,CancellationToken cancellationToken)
        {
            return await _context.TechnicalExaminations
                .Where(t => t.AppointmentDate.Date == date.Date && t.Car.CarEnum == company)
                .CountAsync(cancellationToken);
        }
    }
}
