using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.Car;
using AppDomainCore.Contract.User;
using AppDomainCore.Entities;

namespace AppDomainService
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Car? GetById(int id)
        {
           return _repository.GetById(id);
        }

        public void Add(Car car)
        {
            if (car == null)
            {
                throw new Exception("Error NotNull");

            }
            _repository.Add(car);
        }

        public List<Car> GetCars()
        {
           return _repository.GetCars();
        }

        public void Update(int id, Car car)
        {
            _repository.Update(id, car);
        }
    }
}
