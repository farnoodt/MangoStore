using Mango.Services.ProductAPI.Models.Dto;


namespace Mango.Services.ProductAPI.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategoryById(int CategoryId);
        Task<CategoryDto> CreateOrUpdateCategory(CategoryDto categoryDto);
        Task<bool> DeleteCategory(int CategoryId);
    }
}
