using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Enum
{
    public enum RoleUserEnum
    {
        [Display(Name = "مدیر")]
        Admin = 1,
        [Display(Name = "کاربر")]
        User = 2,
    }
}
