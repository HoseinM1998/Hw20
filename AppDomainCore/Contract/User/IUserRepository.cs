using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.User
{
    public interface IUserRepository
    {
        Task Add(Entities.User user, CancellationToken cancellationToken);
        Task<Entities.User?> GetById(int id, CancellationToken cancellationToken);
        Task<Entities.User?> GetByUserName(string userName, CancellationToken cancellationToken);
    }
}
