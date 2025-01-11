using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Entities
{
    public class TechnicalExamination
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
        public Car Car { get; set; }
        public List<TechnicalExamination> OldCar { get; set; }

    }
}
