using AppDomainCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInfraDbSqlServer.Configurations
{
    public class RoleConfigration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Users)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId)  
                .OnDelete(DeleteBehavior.NoAction);



            builder.HasData(new List<Role>()
            {
                new Role() { Id = 1, Title = "Admin" },
                new Role() { Id = 2, Title = "User" }
            });



        }
    }
}
