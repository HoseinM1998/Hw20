using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Entities;
using AppDomainCore.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppInfraDbSqlServer.Configurations
{
    public class CarConfigration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasMany(x => x.TechnicalExamination)
                .WithOne(x => x.Car)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Car>()
            {
                new Car(){Id = 1 , Model = "206 تیپ2" ,CarEnum = CompanyCarEnum.IranKhodro},
                new Car(){Id = 2 , Model = "206 تیپ5" ,CarEnum = CompanyCarEnum.IranKhodro},
                new Car(){Id = 3 , Model = "پارس" ,CarEnum = CompanyCarEnum.IranKhodro},
                new Car(){Id = 4 , Model = "405 slx" ,CarEnum = CompanyCarEnum.IranKhodro},
                new Car(){Id = 5 , Model = "تارا" ,CarEnum = CompanyCarEnum.IranKhodro},
                new Car(){Id = 6 , Model = "دنا" ,CarEnum = CompanyCarEnum.IranKhodro},
                new Car(){Id = 7 , Model = "رانا" ,CarEnum = CompanyCarEnum.IranKhodro},
                new Car(){Id = 8 , Model = "207" ,CarEnum = CompanyCarEnum.IranKhodro},
                new Car(){Id = 9 , Model = "پراید 111" ,CarEnum = CompanyCarEnum.Saipa},
                new Car(){Id = 10 , Model = "پراید 131" ,CarEnum = CompanyCarEnum.Saipa},
                new Car(){Id = 11 , Model = "کوییک" ,CarEnum = CompanyCarEnum.Saipa},
                new Car(){Id = 12 , Model = "کوییک ار" ,CarEnum = CompanyCarEnum.Saipa},
                new Car(){Id = 13 , Model = "کوییک اس" ,CarEnum = CompanyCarEnum.Saipa},
                new Car(){Id = 14 , Model = "کوییک جی ایکس" ,CarEnum = CompanyCarEnum.Saipa},
                new Car(){Id = 15 , Model = "ساینا" ,CarEnum = CompanyCarEnum.Saipa},
                new Car(){Id = 16 , Model = "ساینا اس" ,CarEnum = CompanyCarEnum.Saipa},
                new Car(){Id = 17 , Model = "شاهین" ,CarEnum = CompanyCarEnum.Saipa},
            });

        }
    }
}
