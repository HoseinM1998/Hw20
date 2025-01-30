using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.User;
using AppDomainCore.Entities;
using AppInfraDbInMemory;

namespace AppDomainAppService
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Register(User user,CancellationToken cancellationToken)
        {
            try
            {
                await _userService.Add(user, cancellationToken);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Add User");
            }
        }

        public async Task<bool> Login(string username, string password, CancellationToken cancellationToken)
        {
            var user =await _userService.GetByUserName(username, cancellationToken);
            if (user == null)
            {
                return false;
            }

            if (user.Password != password)
            {
                return false;
            }
            InMemory.CurentUser = user;
            return true;
        }

        public void Logout()
        {
            InMemory.CurentUser=null;
            
        }
    }
}
