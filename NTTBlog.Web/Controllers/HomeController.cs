using Microsoft.AspNetCore.Mvc;
using NTTBlog.Service.Services.Abstraction;
using NTTBlog.Web.Models;
using System.Diagnostics;

namespace NTTBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;

        public HomeController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid? categoryId, int currentPage=1,int pagaSize=3, bool isAscending = false)
        {
            var articles = await _articleService.GettAllByPagingAsync(categoryId, currentPage, pagaSize, isAscending);
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string keyWord, int currentPage = 1, int pagaSize = 3, bool isAscending = false)
        {
            var articles = await _articleService.SearchAsync(keyWord, currentPage, pagaSize, isAscending);
            return View(articles);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var article = await _articleService.GetArticleWithCategoryAsync(id);
            return View(article);
        }

        public async Task<IActionResult> Contact()
        {
            
            return View();
        }


    }
}
