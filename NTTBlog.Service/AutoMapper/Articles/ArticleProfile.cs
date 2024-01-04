using AutoMapper;
using NTTBlog.Entity.Entites;
using NTTBlog.Entity.VM.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Service.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleVM,Article>().ReverseMap();
            
            CreateMap<ArticleUpdateVM, Article>().ReverseMap();
            CreateMap<ArticleUpdateVM, ArticleVM>().ReverseMap();
            CreateMap<ArticleAddVM, Article>().ReverseMap();
        }
    }
}
