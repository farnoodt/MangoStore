

namespace Mango.Services.ProductAPI.Models.Dto
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
      
        public List<SubCategory> subCategories{ get; set; }
    }
}
