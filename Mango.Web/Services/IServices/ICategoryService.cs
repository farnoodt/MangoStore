
using Mango.Web.Models.Dto;

namespace Mango.Web.Services.IServices
{
    public interface ICategoryService
    {
        Task<T> GetAllCategoriesAsync<T>();
        Task<T> GetCategoryByIdAsync<T>(int id);
        Task<T> CreateCategoryAsync<T>(CategoryDto categoryDto);
        Task<T> UpdateCategoryAsync<T>(CategoryDto categoryDto);
        Task<T> DeleteCategoryAsync<T>(int id);
    }
}
