using AutoMapper;
using Mango.Services.ProductAPI.DBContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.DBContexts.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _Mapper;
        public ProductRepository(ApplicationDbContext db , IMapper Mapper)
        {
            _db = db;
            _Mapper = Mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _Mapper.Map<ProductDto, Product>(productDto);
            if(product.ProductId >0)
            {
                _db.producs.Update(product);
            }
            else
            {
                _db.producs.Add(product);
            }

            await _db.SaveChangesAsync();
            return _Mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> Delete(int productId)
        {
            try
            {
                Product product = await _db.producs.FirstOrDefaultAsync(x => x.ProductId == productId);
                if (product == null)
                    return false;
                _db.producs.Remove(product);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.producs.Where(x=>x.ProductId==productId).FirstOrDefaultAsync();
            return _Mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _db.producs.ToListAsync();
            return _Mapper.Map<List<ProductDto>>(productList);
        }
    }
}
