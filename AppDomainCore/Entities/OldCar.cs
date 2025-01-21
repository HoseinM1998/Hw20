using AppDomainCore.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Entities
{
    public class OldCar 
    {
        [Display(Name = "ایدی")]
        public int Id { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "شماره تلفن")]
        public string Phone { get; set; }

        [Display(Name = "کدملی")]
        public string NationalCode { get; set; }

        [Display(Name = "شماره پلاک")]
        public string CarLicensePlate { get; set; }

        [Display(Name = "سال تولید")]
        public DateTime YearProduction { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }


        [Display(Name = "ایدی ماشین")]
        public int CarId { get; set; }

        [Display(Name = "تاریخ درخواست")]
        public DateTime RequestDate { get; set; }

        [Display(Name = "مدل")]
        [Required(ErrorMessage = "وارد کردن مدل اجباری است")]
        public string? Model { get; set; }


        [Display(Name = "شرکت")]
        [Required(ErrorMessage = "انتخاب کردن شرکت اجباری است")]
        public CompanyCarEnum? CarEnum { get; set; }


    }
}
