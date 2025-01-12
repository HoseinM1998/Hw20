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
    }
}
