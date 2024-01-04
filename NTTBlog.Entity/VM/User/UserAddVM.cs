using Microsoft.AspNetCore.Http;
using NTTBlog.Entity.IdentityEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Entity.VM.User
{
    public  class UserAddVM
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid RoleId { get; set; }
       

        public List<AppRole> Roles { get; set; }
    }
}
