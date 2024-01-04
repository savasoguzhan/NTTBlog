using AutoMapper;
using NTTBlog.Entity.Entites;
using NTTBlog.Entity.VM.Categories;
using NTTBlog.Entity.VM.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Service.AutoMapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryVM, Category>().ReverseMap();
            CreateMap<CategoryAddVM, Category>().ReverseMap();
            CreateMap<CategoryUpdateVM, Category>().ReverseMap();

        }
    }
}
