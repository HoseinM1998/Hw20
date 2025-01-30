using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.User
{
    public interface IUserAppService
    {
        Task<Entities.User> Register(Entities.User user, CancellationToken cancellationToken);
        Task<bool> Login(string username, string password, CancellationToken cancellationToken);
        public void Logout();
    }
}
