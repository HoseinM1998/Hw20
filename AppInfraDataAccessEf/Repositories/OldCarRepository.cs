using AppDomainCore.Entities;
using AppInfraDbSqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInfraDataAccessEf.Repositories
{
    public class OldCarRepository
    {

        private readonly AppDbContext _context;

        public OldCarRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddOldCAr(OldCar oldCar)
        {
            _context.OldCars.Add(oldCar);
            _context.SaveChanges();
        }


        public List<OldCar> GetAllOldCar()
        {
            return _context.OldCars.Include(C => C.Car).AsNoTracking().ToList();

        }
    }
}
