using NTTBlog.Core.Entites;
using NTTBlog.Entity.Enums;
using NTTBlog.Entity.IdentityEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Entity.Entites
{
    public class Image : BaseEntity
    {
        public Image()
        {
            
        }
        public Image(string url, string filetype, string createdBy)
        {
            Url = url;
            FileType = filetype;
            CreatedBy = createdBy;
            
        }
        public string Url { get; set; }
        public string FileType { get; set; }

        


        public ICollection<Article> Articles { get; set; }

        public ICollection<AppUser> Users { get; set; }
    }
}
