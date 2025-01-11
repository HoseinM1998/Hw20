using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.User
{
    public interface IUserAppService
    {
        public Entities.User Register(Entities.User user);
        public Entities.User Login(string username, string password);

        public bool Logout();
    }
}
