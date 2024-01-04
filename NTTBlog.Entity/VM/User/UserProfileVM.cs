using Microsoft.AspNetCore.Http;
using NTTBlog.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Entity.VM.User
{
    public class UserProfileVM
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IFormFile? Photo { get; set; }
        public Image? Image { get; set; }
    }
}
