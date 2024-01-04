using Microsoft.AspNetCore.Mvc;
using NTTBlog.Service.Services.Abstraction;

namespace NTTBlog.Web.ViewComponents
{
    public class HomeCategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public HomeCategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoires =  await _categoryService.Take12CategoriesAsync();
            return View(categoires);
        }
    }
}
