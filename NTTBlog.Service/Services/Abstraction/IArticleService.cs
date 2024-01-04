using NTTBlog.Entity.Entites;
using NTTBlog.Entity.VM.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Service.Services.Abstraction
{
    public interface IArticleService
    {

        /// <summary>
        /// An asynchronous method that retrieves all articles with category information.
        /// </summary>
        /// <returns>Returns SuccessDataResult<List<ArticleVM>> or ErrorDataResult<List<ArticleVM>>.</returns>
        Task<List<ArticleVM>> GetAllArticleWithCategoryAsync();



        Task<ArticleListVM> GettAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);

        Task<ArticleListVM> SearchAsync(string keyWord, int currentPage = 1, int pageSize = 3, bool isAscending = false);



        Task<List<ArticleVM>> GetAllPassiveArticle();



        Task<ArticleVM> GetAllRecentAddArticle();








        /// <summary>
        /// Creates a new article asynchronously based on the provided ArticleAddVM.
        /// </summary>
        /// <param name="articleAddVM">The view model containing information for creating the article.</param>
        /// <returns>
        /// Returns Task representing the asynchronous operation.
        /// </returns>

        Task CreateArticleAsync(ArticleAddVM articleAddVM);




        /// <summary>
        /// Retrieves an article with its associated category information asynchronously.
        /// </summary>
        /// <param name="articleId">The unique identifier of the article to retrieve.</param>
        /// <returns>
        /// Returns a Task representing the asynchronous operation with the result of type ArticleVM.
        /// </returns>
        Task<ArticleVM> GetArticleWithCategoryAsync(Guid articleId);



        /// <summary>
        /// Updates an existing article asynchronously based on the provided ArticleUpdateVM.
        /// </summary>
        /// <param name="articleUpdateVM">The view model containing updated information for the article.</param>
        /// <returns>
        /// Returns a Task representing the asynchronous operation.
        /// </returns>
        Task UpdateArticleAsync(ArticleUpdateVM articleUpdateVM);



        /// <summary>
        /// Soft deletes an article by marking it as inactive based on the provided articleId.
        /// </summary>
        /// <param name="articleId">The unique identifier of the article to soft delete.</param>
        /// <returns>
        /// Returns a Task representing the asynchronous operation.
        /// </returns>
        Task SoftDeleteArticle(Guid articleId);




        Task UndoStatusArticle(Guid articleId);
    }
}
