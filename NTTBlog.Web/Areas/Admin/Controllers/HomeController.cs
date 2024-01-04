using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTTBlog.Entity.IdentityEntites;
using NTTBlog.Service.Services.Abstraction;
using System.Security.AccessControl;
using System.Security.Claims;

namespace NTTBlog.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(IArticleService articleService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticleWithCategoryAsync();
            var logInUser= await _userManager.GetUserAsync(HttpContext.User);
            return View(articles);
        }
    }
}
