using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using NTTBlog.DataAccessLayer.UnitOfWorks;
using NTTBlog.Entity.Entites;
using NTTBlog.Entity.Enums;
using NTTBlog.Entity.VM.Articles;
using NTTBlog.Entity.VM.NewFolder;
using NTTBlog.Service.Extension;
using NTTBlog.Service.Helpers.ImageHelper;
using NTTBlog.Service.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IImageHelper _imageHelper;
        private readonly ClaimsPrincipal _user;



        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            _httpContextAccessor = httpContextAccessor;
            _imageHelper = imageHelper;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<ArticleListVM> GettAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = categoryId == null
                ? await _unitOfWork.GetRepository<Article>().GetAllAsync(a => a.IsPublish, c => c.Category, i => i.Image, u => u.User)
                : await _unitOfWork.GetRepository<Article>().GetAllAsync(c => c.CategoryId == categoryId && c.IsPublish, x => x.Category, i => i.Image, u => u.User);

            var sortedArticle = isAscending
                ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListVM
            {
                Articles = sortedArticle,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }



        public async Task<List<ArticleVM>> GetAllArticleWithCategoryAsync()
        {

            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsPublish, x => x.Category, i => i.Image);
            var map = _mapper.Map<List<ArticleVM>>(articles);
            return map;
        }

        public async Task CreateArticleAsync(ArticleAddVM articleAddVM)
        {

            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var imageUpload = await _imageHelper.UpLoad(articleAddVM.Title, articleAddVM.Photo, ImageType.Post);

            Image image = new(imageUpload.FullName, articleAddVM.Photo.ContentType, userEmail);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);

            var article = new Article
            {
                Title = articleAddVM.Title,
                Content = articleAddVM.Content,
                CategoryId = articleAddVM.CategoryId,
                Tags = articleAddVM.Tags,
                UserId = userId,
                CreatedBy = userEmail,
                ImageId = image.Id

            };

            await _unitOfWork.GetRepository<Article>().AddAsync(article);
            await _unitOfWork.SaveAsync();

        }

        public async Task<ArticleVM> GetArticleWithCategoryAsync(Guid articleId)
        {

            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsPublish && x.Id == articleId, x => x.Category, i => i.Image, u =>u.User);
            var map = _mapper.Map<ArticleVM>(article);
            return map;
        }

        public async Task UpdateArticleAsync(ArticleUpdateVM articleUpdateVM)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsPublish && x.Id == articleUpdateVM.Id, x => x.Category, i => i.Image);

            if (articleUpdateVM.Photo != null)
            {
                _imageHelper.Delete(article.Image.Url);
                var imageUpload = _imageHelper.UpLoad(articleUpdateVM.Title, articleUpdateVM.Photo, ImageType.Post);
                Image image = new Image();
                await _unitOfWork.GetRepository<Image>().AddAsync(image);

                article.ImageId = image.Id;
            }

            article.Title = articleUpdateVM.Title;
            article.Content = articleUpdateVM.Content;
            article.Tags = articleUpdateVM.Tags;
            article.CategoryId = articleUpdateVM.CategoryId;
            article.Tags = articleUpdateVM.Tags;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;

            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);

            await _unitOfWork.SaveAsync();
        }

        public async Task SoftDeleteArticle(Guid articleId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsPublish = false;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;
            
            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }

       
        public async Task<List<ArticleVM>> GetAllPassiveArticle()
        {
            var article = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsPublish, x => x.Category);

            var map = _mapper.Map<List<ArticleVM>>(article);

            return map;

        }

        public async Task UndoStatusArticle(Guid articleId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

            article.IsPublish = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;
            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsync();
        }

        public async Task<ArticleListVM> SearchAsync(string keyWord, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(a => a.IsPublish && (a.Title.Contains(keyWord) || a.Content.Contains(keyWord)), a => a.Category, i => i.Image, u => u.User);



            var sortedArticle = isAscending
                ? articles.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListVM
            {
                Articles = sortedArticle,

                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }

        public async Task<ArticleVM> GetAllRecentAddArticle()
        {
            var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsPublish, x => x.Category);
            var map = _mapper.Map<ArticleVM>(articles);

            var sortedArticles = articles.OrderBy(x => x.CreatedDate);

            return new ArticleVM();

        }
    }
}
