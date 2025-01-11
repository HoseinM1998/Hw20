using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.Car
{
    public interface ICarRepository
    {
        public List<Entities.Car> GetCars();
    }
}
