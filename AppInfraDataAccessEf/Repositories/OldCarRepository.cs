using AppDomainCore.Entities;
using AppInfraDbSqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.OldCar;

namespace AppInfraDataAccessEf.Repositories
{
    public class OldCarRepository : IOldCarRepository
    {

        private readonly AppDbContext _context;

        public OldCarRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddOldCAr(OldCar oldCar, CancellationToken cancellationToken)
        {
            await _context.OldCars.AddAsync(oldCar, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }


        public async Task<List<OldCar>> GetAllOldCar(CancellationToken cancellationToken)
        {
            return await _context.OldCars.Include(c =>c.Car).AsNoTracking().ToListAsync(cancellationToken);

        }
    }
}
