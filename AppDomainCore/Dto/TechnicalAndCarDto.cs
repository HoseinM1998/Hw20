using AppDomainCore.Entities;
using AppDomainCore.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Dto
{
    public class TechnicalAndCarDto
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "وارد کردن نام و نام خانوادگی اجباری است")]
        public string FullName { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "وارد کردن شماره تلفن اجباری است")]
        [StringLength(11, ErrorMessage = "شماره تلفن11رقم است")]
        public string Phone { get; set; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "وارد کردن کدملی اجباری است")]
        [StringLength(10, ErrorMessage = "کد ملی 10رقم است")]
        public string NationalCode { get; set; }

        [Display(Name = "شماره پلاک")]
        [Required(ErrorMessage = "وارد کردن شماره پلاک اجباری است")]
        public string CarLicensePlate { get; set; }

        [Display(Name = "سال تولید")]
        [Required(ErrorMessage = "وارد کردن سال تولید اجباری است")]
        public DateTime YearProduction { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "وارد کردن ادرس اجباری است")]
        public string Address { get; set; }


        [Display(Name = "ایدی ماشین")]
        [Required(ErrorMessage = "وارد کردن مدل ماشین اجباری است")]
        public int CarId { get; set; }
        public List<Car>? ModelCars { get; set; } = new List<Car>();

        [Display(Name = "تاریخ نوبت")]
        [Required(ErrorMessage = "وارد کردن تاریخ اجباری است")]
        public DateTime AppointmentDate { get; set; }


    }
}
