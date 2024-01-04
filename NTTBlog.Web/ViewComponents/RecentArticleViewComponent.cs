using Microsoft.AspNetCore.Mvc;
using NTTBlog.Service.Services.Abstraction;

namespace NTTBlog.Web.ViewComponents
{
    public class RecentArticleViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;

        public RecentArticleViewComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var articles = await _articleService.GetAllArticleWithCategoryAsync();
            return View(articles);
        }
    }
}
