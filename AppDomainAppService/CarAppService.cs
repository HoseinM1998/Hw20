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

        public void Delete(int id)
        {
            try
            {
               _carService.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public Car? GetById(int id)
        {
            try
            {
               return _carService.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public void Create(Car car)
        {
            try
            {
               _carService.Add(car);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public List<Car> GetCars()
        {
            try
            {
               return _carService.GetCars();
            }
            catch (Exception ex)
            {
                throw new Exception("Error GetCars");
            }
        }

        public void Update(int id, Car car)
        {
            try
            {
                _carService.Update(id,car);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
