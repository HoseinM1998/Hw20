using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.OldCar
{
    public interface IOldCarRepository
    {
        Task<List<Entities.OldCar>> GetAllOldCar(CancellationToken cancellationToken);
        Task AddOldCAr(Entities.OldCar oldCar, CancellationToken cancellationToken);

    }
}
