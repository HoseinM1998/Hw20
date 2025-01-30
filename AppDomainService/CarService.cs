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

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _repository.Delete(id, cancellationToken);
        }

        public async Task<Car?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetById(id, cancellationToken);
        }

        public async Task Add(Car car, CancellationToken cancellationToken)
        {
            if (car == null)
            {
                throw new Exception("Error NotNull");

            }
            await _repository.Add(car, cancellationToken);
        }

        public async Task<List<Car>> GetCars(CancellationToken cancellationToken)
        {
            return await _repository.GetCars(cancellationToken);
        }

        public async Task Update(int id, Car car, CancellationToken cancellationToken)
        {
           await _repository.Update(id, car, cancellationToken);
        }
    }
}
