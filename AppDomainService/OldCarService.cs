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
        public async Task AddOldCAr(OldCar oldCar,CancellationToken cancellationToken)
        {
            if (oldCar != null)
            {
               await _repository.AddOldCAr(oldCar, cancellationToken);
            }
        }

        public async Task<List<OldCar>> GetAllOldCar(CancellationToken cancellationToken)
        {
           return await _repository.GetAllOldCar(cancellationToken);
        }
    }
}
