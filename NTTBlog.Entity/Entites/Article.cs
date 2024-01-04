using NTTBlog.Core.Entites;
using NTTBlog.Entity.IdentityEntites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Entity.Entites
{
    public class Article : BaseEntity
    {
        public Article()
        {
            
        }
        public Article(string title,string content, Guid userId, Guid categoryId, Guid imageId,string tags, string createdBy)
        {
            Title = title;
            Content = content;
            UserId = userId;
            CategoryId = categoryId;
            ImageId = imageId;
            Tags = tags;
            CreatedBy = createdBy;
        }
       

        public string Title { get; set; }
        public string Tags { get; set; }

        public string Content { get; set; }
        public int  ViewCount { get; set; } = 0;
        public bool IsPublish { get; set; } = true;
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public Guid? ImageId { get; set; }

        public Image Image { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }   

        



    }
}
