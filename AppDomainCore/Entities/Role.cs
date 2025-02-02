using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AppDomainCore.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<User>? Users { get; set; }

    }
}
