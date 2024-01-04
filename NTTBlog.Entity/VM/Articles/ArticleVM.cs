using NTTBlog.Entity.Entites;
using NTTBlog.Entity.VM.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Entity.VM.Articles
{
    public class ArticleVM
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Tags { get; set; }
        public string Content { get; set; }

        public CategoryVM Category { get; set; }

        public Image Image { get; set; }


        public DateTime CreateDate { get; set; }
        public string  CreatedBy { get; set; }

        public bool IsPublish { get; set; }
    }
}
