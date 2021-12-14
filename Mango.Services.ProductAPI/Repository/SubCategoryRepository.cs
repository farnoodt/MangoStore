using AutoMapper;
using Mango.Services.ProductAPI.DBContexts;
using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _Mapper;

        public SubCategoryRepository(ApplicationDbContext db, IMapper Mapper)
        {
            this._db = db;
            this._Mapper = Mapper;
        }
        public async Task<SubCategoryDto> CreateOrUpdateCategory(SubCategoryDto subcategoryDto)
        {
            SubCategory subcategory = _Mapper.Map<SubCategoryDto, SubCategory>(subcategoryDto);
            if (subcategory.SubCategoryId > 0)
            {
                _db.SubCategories.Update(subcategory);
            }
            else
            {
                _db.SubCategories.Add(subcategory);
            }
            await _db.SaveChangesAsync();
            return _Mapper.Map<SubCategory, SubCategoryDto>(subcategory);
        }

        public async Task<bool> DeleteCategory(int subCategoryId)
        {
            try
            {
                SubCategory subCategory = _db.SubCategories.Where(x => x.SubCategoryId == subCategoryId).Include(x=>x.products).FirstOrDefault();

                if (subCategory != null && subCategory.products.Count ==0 )
                    _db.SubCategories.Remove(subCategory);

                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SubCategoryDto>> GetSubCategories()
        {
            List<SubCategory> subcategory = await _db.SubCategories.Include(x=>x.category).ToListAsync();
            subcategory.ForEach(
                   g =>
                   {
                       if (g != null && g.category != null && g.category.subCategories != null)
                           g.category.subCategories.Clear();
                   });
            return _Mapper.Map<List<SubCategoryDto>>(subcategory);
        }

        public async Task<SubCategoryDto> GetSubCategoryById(int subCategoryId)
        {
            SubCategory subCategory = await _db.SubCategories.Where(x => x.SubCategoryId == subCategoryId).Include(x=>x.category).FirstOrDefaultAsync();
            if (subCategory.category.subCategories != null)
                subCategory.category.subCategories.Clear();
                  
            return _Mapper.Map<SubCategory, SubCategoryDto>(subCategory);
        }
    }
}
