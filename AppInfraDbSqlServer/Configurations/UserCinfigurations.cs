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
    public class UserCinfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasData(new List<User>()
            {
                new User(){Id = 1 , UserName = "Admin" , Password = "12345@",Phone = "09913466961",Role = RoleUserEnum.Admin},
                new User(){Id = 2 , UserName = "Admin2" , Password = "12345@",Phone = "03103905561",Role = RoleUserEnum.Admin},
                new User(){Id = 3 , UserName = "User" , Password = "12345@",Phone = "03103905561",Role = RoleUserEnum.Admin},
                new User(){Id = 4 , UserName = "User2" , Password = "12345@",Phone = "03103905561",Role = RoleUserEnum.Admin},



            });
        }
    }
}
