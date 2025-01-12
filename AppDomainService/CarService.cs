using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Car> GetCars()
        {
           return _repository.GetCars();
        }
    }
}
