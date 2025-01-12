using AppDomainCore.Entities;
using AppInfraDbSqlServer.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInfraDbSqlServer
{
    
    public class AppDbContext : DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{

        //}
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<OldCar> OldCarsCars { get; set; }

        public DbSet<TechnicalExamination> TechnicalExaminations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfigration());
            modelBuilder.ApplyConfiguration(new UserCinfigurations());
            modelBuilder.ApplyConfiguration(new TechnicalExaminationConfiguration());


            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=DESKTOP-78B19T2\SQLEXPRESS; Initial Catalog=Hw-20; User Id=sa; Password=13771377; TrustServerCertificate=True;");
        }
    }
}
