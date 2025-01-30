using AppDomainCore.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.Car;
using AppDomainCore.Entities;

namespace AppDomainAppService
{
    public class CarAppservice : ICarAppService
    {
        private readonly ICarService _carService;

        public CarAppservice(ICarService carService)
        {
            _carService = carService;
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
              await _carService.Delete(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Car?> GetById(int id, CancellationToken cancellationToken)
        {
            try
            {
               return await _carService.GetById(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task Create(Car car, CancellationToken cancellationToken)
        {
            try
            {
              await _carService.Add(car, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<List<Car>> GetCars(CancellationToken cancellationToken)
        {
            try
            {
               return await _carService.GetCars(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error GetCars");
            }
        }

        public async Task Update(int id, Car car, CancellationToken cancellationToken)
        {
            try
            {
               await _carService.Update(id,car, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
