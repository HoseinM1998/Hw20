using AppInfraDbSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.Car;
using AppDomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace AppInfraDataAccessEf.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Car car, CancellationToken cancellationToken)
        {
           await _context.Cars.AddAsync(car, cancellationToken);
           await _context.SaveChangesAsync(cancellationToken);

        }
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var car =await _context.Cars.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (car != null)
            {
                _context.Cars.Remove(car);
               await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<Car?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _context.Cars.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<List<Car>> GetCars(CancellationToken cancellationToken)
        {
            return await _context.Cars.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task Update(int id, Car car, CancellationToken cancellationToken)
        {
            var updateCar =await _context.Cars.FindAsync(id, cancellationToken);
            if (updateCar != null)
            {
                updateCar.Model = car.Model;
                updateCar.CarEnum = car.CarEnum;
               await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
