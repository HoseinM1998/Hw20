using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.OldCar
{
    public interface IOldCarRepository
    {
        public List<Entities.OldCar> GetCars();
        public void Add(Entities.OldCar oldCar);


    }
}
