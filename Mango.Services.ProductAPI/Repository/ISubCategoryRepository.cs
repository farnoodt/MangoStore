using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI.Repository
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategoryDto>> GetSubCategories();
        Task<SubCategoryDto> GetSubCategoryById(int subCategoryId);
        Task<SubCategoryDto> CreateOrUpdateCategory(SubCategoryDto subcategoryDto);
        Task<bool> DeleteCategory(int subCategoryId);
    }
}
