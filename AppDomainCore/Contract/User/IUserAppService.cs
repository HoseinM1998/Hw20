using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Dto;
using Microsoft.AspNetCore.Identity;

namespace AppDomainCore.Contract.User
{
    public interface IUserAppService
    {
        Task<IdentityResult> Register(UserDto user , CancellationToken cancellationToken);
        Task<IdentityResult> Login(string username, string password );
        public void Logout();
    }
}
