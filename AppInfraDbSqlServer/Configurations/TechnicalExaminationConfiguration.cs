using AppDomainCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppInfraDbSqlServer.Configurations
{
    public class TechnicalExaminationConfiguration : IEntityTypeConfiguration<TechnicalExamination>
    {

        public void Configure(EntityTypeBuilder<TechnicalExamination> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
