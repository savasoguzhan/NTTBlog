using NTTBlog.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Entity.Entites
{
    public class Category: BaseEntity
    {
        public Category()
        {
            
        }
        public Category(string name,string createdBy)
        {
            Name = name;
            CreatedBy = createdBy;
        }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }

    }
}
