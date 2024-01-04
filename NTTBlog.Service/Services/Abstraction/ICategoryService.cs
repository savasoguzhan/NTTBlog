using NTTBlog.Entity.Entites;
using NTTBlog.Entity.VM.Categories;
using NTTBlog.Entity.VM.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Service.Services.Abstraction
{
    public interface ICategoryService
    {

        /// <summary>
        /// Retrieves all categories asynchronously.
        /// </summary>
        /// <returns>
        /// Returns a Task representing the asynchronous operation with the result of type List<CategoryVM>.
        /// </returns>
        public Task<List<CategoryVM>> GetAllCategories();




        /// <summary>
        /// Creates a new category asynchronously based on the provided CategoryAddVM.
        /// </summary>
        /// <param name="categoryAddVM">The view model containing information for creating the category.</param>
        /// <returns>
        /// Returns a Task representing the asynchronous operation.
        /// </returns>

        Task CreateCategoryAsync(CategoryAddVM categoryAddVM);





        /// <summary>
        /// Retrieves a category asynchronously based on the provided unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category to retrieve.</param>
        /// <returns>
        /// Returns a Task representing the asynchronous operation with the result of type Category.
        /// </returns>
        Task<Category> GetCategoryByGuid(Guid id);



        /// <summary>
        /// Creates or updates a category asynchronously based on the provided CategoryUpdateVM.
        /// </summary>
        /// <param name="categoryUpdateVM">The view model containing information for creating or updating the category.</param>
        /// <returns>
        /// Returns a Task representing the asynchronous operation with the result of type string.
        /// </returns>
        Task<string> CreateUpdateAsync(CategoryUpdateVM categoryUpdateVM);

        Task<List<CategoryVM>> Take12CategoriesAsync();



    }
}
