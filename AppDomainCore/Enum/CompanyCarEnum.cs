using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Enum
{
    public enum CompanyCarEnum
    {
        [Display(Name = "ایرانخودرو")]
        IranKhodro = 1,
        [Display(Name = "سایپا")]
        Saipa = 2,
    }
}
