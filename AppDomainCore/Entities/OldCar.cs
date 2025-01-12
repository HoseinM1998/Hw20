using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Entities
{
    public class OldCar
    {
        public int Id { get; set; }
        public int TechnicalExaminationId { get; set; }
        public TechnicalExamination TechnicalExamination { get; set; }

    }
}
