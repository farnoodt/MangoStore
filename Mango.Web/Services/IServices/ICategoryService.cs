
using Mango.Web.Models.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mango.Web.Services.IServices
{
    public interface ICategoryService : IBaseService
    {
        Task<T> GetAllCategoriesAsync<T>( string token = null);
        Task<T> GetCategoryByIdAsync<T>(int id, string token = null);
        Task<T> CreateCategoryAsync<T>(CategoryDto categoryDto, string token = null);
        Task<T> UpdateCategoryAsync<T>(CategoryDto categoryDto, string token = null);
        Task<T> DeleteCategoryAsync<T>(int id, string token = null);
        Task<IEnumerable<SelectListItem>> GetCategories<T>();
        Task<CategoryViewModelDto> GetAllCategoriesDDAsync<T>(string token = null);

    }
}
