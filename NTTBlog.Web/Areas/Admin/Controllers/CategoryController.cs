using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using NTTBlog.Entity.Entites;
using NTTBlog.Entity.VM.Categories;
using NTTBlog.Service.Extension;
using NTTBlog.Service.Services.Abstraction;

namespace NTTBlog.Web.Areas.Admin.Controllers
{

    [Authorize(Roles = "MasterAdmin")]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<Category> _validator;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public CategoryController(ICategoryService categoryService, IValidator<Category> validator, IMapper mapper, IToastNotification toastNotification)
        {
            _categoryService = categoryService;
            _validator = validator;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddVM categoryAddVM)
        {

            var map = _mapper.Map<Category>(categoryAddVM);
            var result = await _validator.ValidateAsync(map);
            if (result.IsValid)
            {
               await  _categoryService.CreateCategoryAsync(categoryAddVM);
                _toastNotification.AddSuccessToastMessage("New Category is Added");
                return RedirectToAction("Index","Category", new {Area ="Admin"});

            }
            else
            {
                result.AddToModelState(this.ModelState);
                
            }
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> AddWithAjax([FromBody] CategoryAddVM categoryAddVM)
        {
            var map = _mapper.Map<Category>(categoryAddVM);
            var result = await _validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await _categoryService.CreateCategoryAsync(categoryAddVM);
                _toastNotification.AddSuccessToastMessage("New Category is Added");

                return Json("Category Added");

            }
            return Json("FAIL!");
        }

        [HttpGet]
        public async  Task<IActionResult> Update(Guid categoryId)
        {
            var category =  await _categoryService.GetCategoryByGuid(categoryId);
            
            return View( new CategoryUpdateVM() { Id=category.Id, Name=category.Name});
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateVM categoryUpdateVM)
        {
            await _categoryService.CreateUpdateAsync(categoryUpdateVM);
             _toastNotification.AddSuccessToastMessage(" Category is Updated");
                return RedirectToAction("Index","Category", new {Area ="Admin"});

        }

    }
}
