using Mango.Web.Models.Dto;

namespace Mango.Web.Services.IServices
{
    public interface ISubCategoryService
    {
        Task<T> GetAllSubCategoriesAsync<T>(string token = null);
        Task<T> GetSubCategoryByIdAsync<T>(int id, string token = null);
        Task<T> CreateSubCategoryAsync<T>(SubCategoryDto subcategoryDto, string token = null);
        Task<T> UpdateSubCategoryAsync<T>(SubCategoryDto subcategoryDto, string token = null);
        Task<T> DeleteSubCategoryAsync<T>(int id, string token = null);
    }
}
