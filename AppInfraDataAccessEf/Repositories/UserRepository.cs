using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.User;
using AppDomainCore.Entities;
using AppInfraDbSqlServer;
using Microsoft.EntityFrameworkCore;

namespace AppInfraDataAccessEf.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public User? GetById(int id)
        {
            return _context.User.AsNoTracking().FirstOrDefault(u => u.Id == id);
        }

        public User? GetByUserName(string userName)
        {
            return _context.User.AsNoTracking().FirstOrDefault(u => u.UserName == userName);

        }
    }
}
