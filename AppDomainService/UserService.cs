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
        public async Task Add(User user,CancellationToken cancellationToken)
        {
            bool isSpecial = user.Password.Any(s => (s >= 33 && s <= 47) || s == 64);

            if (user.Password.Length < 4|| user.Password.Length > 8 || !isSpecial)
            {
                throw new Exception("Password > 4 Char And One Special Character");
            }

            var userNa =await _repository.GetByUserName(user.UserName, cancellationToken);
            if (userNa != null)
            {
                throw new Exception("Existing UserName");

            }
            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            user.Role = RoleUserEnum.User;
            await _repository.Add(user, cancellationToken);
        }

        public async Task<User?> GetById(int id,CancellationToken cancellationToken)
        {
            var user =await _repository.GetById(id, cancellationToken);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            return user;
        }

        public async Task<User?> GetByUserName(string userName,CancellationToken cancellationToken)
        {
            var user =await _repository.GetByUserName(userName, cancellationToken);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            return user;
        }
    }
}
