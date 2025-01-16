using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.OldCar
{
    public interface IOldCarService
    {
        public List<Entities.OldCar> GetAllOldCar();
        public void AddOldCAr(Entities.OldCar oldCar);
    }
}
