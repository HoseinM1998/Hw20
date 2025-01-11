using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.User
{
    public interface IUserRepository
    {
        public void Add(Entities.User user);
        public Entities.User? GetById(int id);
        public Entities.User? GetByUserName(string userName);
    }
}
