using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTTBlog.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.DataAccessLayer.Context.DataConfig
{
    //Configuration Islemleri Burada 
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Tags).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Content).IsRequired();
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Data Base Deneme",
                Content = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                ViewCount = 13,

                CategoryId = Guid.Parse("9B1056F6-6171-49A5-9BAA-D22C489289B6"),
                
                ImageId = Guid.Parse("1465691C-3690-40B6-9FAB-99A388205514"),
                CreatedBy = "adminTest",
                CreatedDate = DateTime.Now,
                IsPublish = true,
                Tags="deneme",
                UserId= Guid.Parse("538FAB7B-024B-458A-BB52-B2520F3BCC49")
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Data Base Deneme 2",
                Content = " Deneme There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                ViewCount = 7,
                CategoryId=Guid.Parse("E90E9E24-83D4-4B50-AE2C-D3187ABF3D26"),

                ImageId=Guid.Parse("E37A4A99-7458-4089-A6DE-D5DBF52C95CD"),
                CreatedBy = "adminTest",
                CreatedDate = DateTime.Now,
                IsPublish = true,
                Tags="deneme2",
                UserId= Guid.Parse("0A3ADEE6-2F0D-42B7-83D3-22F95F64CCAB")
                
                
            });
        }
    }
}
