using AppInfraDbSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.Car;
using AppDomainCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppInfraDataAccessEf.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Car> GetCars()
        {
            return _context.Cars.AsNoTracking().ToList();
        }
    }
}
