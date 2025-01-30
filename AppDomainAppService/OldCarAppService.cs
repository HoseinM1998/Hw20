
using AppDomainCore.Contract.OldCar;
using AppDomainCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainAppService
{
    public class OldCarAppService : IOldCarAppService
    {
        private readonly IOldCarService _carService;

        public OldCarAppService(IOldCarService carService)
        {
            _carService = carService;
        }

        public async Task<List<OldCar>> GetAllOldCars(CancellationToken cancellationToken)
        {
            try
            {
                return await _carService.GetAllOldCar(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error GetCars");
            }
        }

    
    }
}
