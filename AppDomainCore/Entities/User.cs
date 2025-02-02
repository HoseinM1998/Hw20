using System;
using System.ComponentModel.DataAnnotations;
using AppDomainCore.Enum;
using Microsoft.AspNetCore.Identity;

namespace AppDomainCore.Entities
{
    public class User : IdentityUser<int>
    {

        
        [Required(ErrorMessage = "شماره موبایل الزامی است")]
        [StringLength(11, ErrorMessage = "شماره موبایل باید 11 رقم باشد")]
        public string Mobile { get; set; } = string.Empty;
        public DateTime RegisterAt { get; set; } 
        public int? RoleId { get; set; }

        public Role? Role { get; set; }
    }
}