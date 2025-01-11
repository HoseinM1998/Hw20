using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Enum;

namespace AppDomainCore.Entities
{
    public class User
    {
        [Display(Name = "ایدی")]
        public int Id { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "رمزعبور")]
        public string Password { get; set; }

        [Display(Name = "نقش")]
        public RoleUserEnum Role { get; set; }


    }
}
