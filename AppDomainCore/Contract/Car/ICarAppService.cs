using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.Car
{
    public interface ICarAppService
    {
        public List<Entities.Car> GetCars();
    }
}
