using Microsoft.AspNetCore.Http;
using NTTBlog.Entity.Entites;
using NTTBlog.Entity.VM.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Entity.VM.Articles
{
    public class ArticleAddVM
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }

        public Guid CategoryId { get; set; }

        public IFormFile Photo { get; set; }

        public IList<CategoryVM> Categories { get; set; }
    }
}
