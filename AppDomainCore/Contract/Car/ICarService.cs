using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.Car
{
    public interface ICarService
    {
        Task<List<Entities.Car>> GetCars(CancellationToken cancellationToken);
        Task Add(Entities.Car car, CancellationToken cancellationToken);
        Task Update(int id, Entities.Car car, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<Entities.Car?> GetById(int id, CancellationToken cancellationToken);

    }

}

