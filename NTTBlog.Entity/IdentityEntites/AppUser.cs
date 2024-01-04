using Microsoft.AspNetCore.Identity;
using NTTBlog.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Entity.IdentityEntites
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Firstname { get; set; }

        public string LastName { get; set; }

        public Guid ImageId { get; set; } = Guid.Parse("1465691C-3690-40B6-9FAB-99A388205514");
        public Image Image { get; set; }

        public ICollection<Article > Articles { get; set; }
    }
}
