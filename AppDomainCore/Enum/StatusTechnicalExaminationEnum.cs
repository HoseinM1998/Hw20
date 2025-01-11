using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Enum
{
    public enum StatusTechnicalExaminationEnum
    {
        [Display(Name = "تایید")]
        Confirmation = 1,
        [Display(Name = "لغو")]
        Cancel = 2,
        [Display(Name = "درحال بررسی")]
        UnderReview = 3


    }
}
