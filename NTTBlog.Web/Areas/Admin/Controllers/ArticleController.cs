using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using NTTBlog.Entity.Entites;
using NTTBlog.Entity.VM.Articles;
using NTTBlog.Service.Services.Abstraction;

namespace NTTBlog.Web.Areas.Admin.Controllers
{

    [Authorize(Roles="MasterAdmin")]
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        private readonly IToastNotification _toastNotification;
        private readonly IValidator _validator;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IToastNotification toastNotification)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _mapper = mapper;

            _toastNotification = toastNotification;
            
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticleWithCategoryAsync();
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> PassiveArticle()
        {
            var articles = await _articleService.GetAllPassiveArticle();
            return View(articles);
        }




        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategories();
            return View(new ArticleAddVM { Categories = categories });
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddVM articleAddVM)
        {



            await _articleService.CreateArticleAsync(articleAddVM);
            _toastNotification.AddSuccessToastMessage("New Article is Added");

            return RedirectToAction("Index", "Article", new { Area = "Admin" });






            //var categories = await _categoryService.GetAllCategories();
            //return View(new ArticleAddVM { Categories = categories });

        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await _articleService.GetArticleWithCategoryAsync(articleId);
            var categories = await _categoryService.GetAllCategories();

            var articleUpdateDto = _mapper.Map<ArticleUpdateVM>(article);
            articleUpdateDto.Categories = categories;

            return View(articleUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateVM articleUpdateVM)
        {
            //var map = _mapper.Map<Article>(articleUpdateVM);
            //var result = await _validator.ValidateAsync(map);
            await _articleService.UpdateArticleAsync(articleUpdateVM);

            var categories = await _categoryService.GetAllCategories();

            articleUpdateVM.Categories = categories;
            _toastNotification.AddSuccessToastMessage("Article is Updated");
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            await _articleService.SoftDeleteArticle(articleId);
            _toastNotification.AddSuccessToastMessage("Succes");

            return RedirectToAction("Index", "Article", new { Area = "Admin" });

        }

        public async Task<IActionResult> UndoStatus(Guid articleId)
        {
            await _articleService.UndoStatusArticle(articleId);
            _toastNotification.AddSuccessToastMessage("Succes");

            return RedirectToAction("Index", "Article", new { Area = "Admin" });

        }
    }
}
