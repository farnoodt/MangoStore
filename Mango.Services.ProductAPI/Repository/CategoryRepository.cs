using AutoMapper;
using Mango.Services.ProductAPI.DBContexts;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Repository;


namespace Mango.Services.ProductAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _Mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper Mapper)
        {
            this._db = db;
            this._Mapper = Mapper;
        }
        public async Task<CategoryDto> CreateOrUpdateCategory(CategoryDto categoryDto)
        {
            Category category = _Mapper.Map<CategoryDto,Category>(categoryDto);
            if(category.CategoryId>0)
            {
                _db.Categories.Update(category);
            }
            else
            {
                _db.Categories.Add(category);
            }

            await _db.SaveChangesAsync();
            return _Mapper.Map<Category, CategoryDto>(category);
        }

        public async Task<bool> DeleteCategory(int CategoryId)
        {
            try
            {
                Category category = await _db.Categories.Where(x => x.CategoryId == CategoryId).FirstOrDefaultAsync();
                if (category == null)
                    return false;

                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            List<Category> CategoryList = await _db.Categories.ToListAsync();
            return _Mapper.Map<List<CategoryDto>>(CategoryList); 
        }

        public async Task<CategoryDto> GetCategoryById(int CategoryId)
        {
           Category category = await _db.Categories.Where(x => x.CategoryId == CategoryId).FirstOrDefaultAsync();
            return _Mapper.Map<CategoryDto>(category);
        }
    }
}
