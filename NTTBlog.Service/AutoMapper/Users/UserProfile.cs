using AutoMapper;
using NTTBlog.Entity.IdentityEntites;
using NTTBlog.Entity.VM.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserVM>().ReverseMap();
            CreateMap<AppUser, UserAddVM>().ReverseMap();
            CreateMap<AppUser, UserUpdateVM>().ReverseMap();
            CreateMap<AppUser, UserProfileVM>().ReverseMap();
        }
    }
}   
