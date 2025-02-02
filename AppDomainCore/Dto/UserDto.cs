using System.ComponentModel.DataAnnotations;

namespace AppDomainCore.Dto
{
    public class UserDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "نام کاربری الزامی است")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "شماره موبایل الزامی است")]
        [StringLength(11, ErrorMessage = "شماره موبایل باید 11 رقم باشد")]
        public string Mobile { get; set; }

        public int RoleId { get; set; }
    }
}