using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.User;
using AppDomainCore.Entities;
using AppDomainCore.Enum;

namespace AppDomainService
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public void Add(User user)
        {
            bool isSpecial = user.Password.Any(s => (s >= 33 && s <= 47) || s == 64);

            if (user.Password.Length < 5 || user.Password.Length > 10 || !isSpecial)
            {
                throw new Exception("Password > 4 Char And One Special Character");
            }

            var userNa = _repository.GetByUserName(user.UserName);
            if (user != null)
            {
                throw new Exception("Existing UserName");

            }
            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            user.Role = RoleUserEnum.User;
            _repository.Add(user);
        }

        public User? GetById(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            return user;
        }

        public User? GetByUserName(string userName)
        {
            var user = _repository.GetByUserName(userName);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            return user;
        }
    }
}
