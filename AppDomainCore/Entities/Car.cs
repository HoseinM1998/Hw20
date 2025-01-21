using AppDomainCore.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AppDomainCore.Entities
{
    public class Car
    {
        [Display(Name = "ایدی")]
        public int Id { get; set; }


        [Display(Name = "مدل")]
        [Required(ErrorMessage = "وارد کردن مدل اجباری است")]
        public string Model { get; set; }


        [Display(Name = "شرکت")]
        [Required(ErrorMessage = "انتخاب کردن شرکت اجباری است")]
        public CompanyCarEnum CarEnum { get; set; }

        public List<TechnicalExamination>? TechnicalExamination { get; set; }
    }
}
