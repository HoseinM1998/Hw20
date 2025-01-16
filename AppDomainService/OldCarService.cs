using AppDomainCore.Contract.Car;
using AppDomainCore.Contract.OldCar;
using AppDomainCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainService
{
    public class OldCarService : IOldCarService
    {

        private readonly IOldCarRepository _repository;

        public OldCarService(IOldCarRepository repository)
        {
            _repository = repository;
        }
        public void AddOldCAr(OldCar oldCar)
        {
            if (oldCar != null)
            {
                _repository.AddOldCAr(oldCar);
            }
        }

        public List<OldCar> GetAllOldCar()
        {
           return _repository.GetAllOldCar();
        }
    }
}
