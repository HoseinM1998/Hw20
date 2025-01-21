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
        [Required(ErrorMessage = "وارد کردن نام کاربری اجباری است")]
        public string UserName { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "وارد کردن شماره تلفن اجباری است")]
        [StringLength(11, ErrorMessage = "شماره تلفن11رقم است")]
        public string Phone { get; set; }

        [Display(Name = "رمزعبور")]
        [Required(ErrorMessage = "وارد کردن پسوورداجباری است")]
        [Range(5,10, ErrorMessage = "رمز عبور بین5تا10 کاراکتراست")]
        public string Password { get; set; }

        [Display(Name = "نقش")]
        public RoleUserEnum Role { get; set; }


    }
}
