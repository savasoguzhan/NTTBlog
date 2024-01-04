using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NTTBlog.DataAccessLayer.UnitOfWorks;
using NTTBlog.Entity.Entites;
using NTTBlog.Entity.VM.Categories;
using NTTBlog.Entity.VM.NewFolder;
using NTTBlog.Service.Extension;
using NTTBlog.Service.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<List<CategoryVM>> GetAllCategories()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync();
            var map = _mapper.Map<List<CategoryVM>>(categories);
            return map;

        }

        public async Task CreateCategoryAsync(CategoryAddVM categoryAddVM)
        {
            
            var userEmail = _user.GetLoggedInEmail();
            Category category = new(categoryAddVM.Name, userEmail);

            await _unitOfWork.GetRepository<Category>().AddAsync(category);
            await _unitOfWork.SaveAsync();

            

        }

        public async Task<Category> GetCategoryByGuid(Guid id)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByGuidAsync(id);
            return category;
        }


        public async Task<string> CreateUpdateAsync(CategoryUpdateVM categoryUpdateVM)
        {

            var userEmail = _user.GetLoggedInEmail();
            var category = await _unitOfWork.GetRepository<Category>().GetAsync(x => x.Id == categoryUpdateVM.Id);

            category.Name = categoryUpdateVM.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate=DateTime.Now;
            await _unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();

            return category.Name;
           


        }

        public async Task<List<CategoryVM>> Take12CategoriesAsync()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync();
            var map = _mapper.Map<List<CategoryVM>>(categories);
             
            return map.Take(12).ToList(); 
        }
    }
}
