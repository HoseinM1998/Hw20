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

        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();

        }
        public void Delete(int id)
        {
            var car = _context.Cars.FirstOrDefault(p => p.Id == id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }

        public Car? GetById(int id)
        {
            return _context.Cars.AsNoTracking().FirstOrDefault(u => u.Id == id);
        }

        public List<Car> GetCars()
        {
            return _context.Cars.AsNoTracking().ToList();
        }

        public void Update(int id, Car car)
        {
            var updateCar = _context.Cars.Find(id);
            if (updateCar != null)
            {
                updateCar.Model = car.Model;
                updateCar.CarEnum = car.CarEnum;
                _context.SaveChanges();
            }
        }
    }
}
