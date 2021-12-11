

namespace Mango.Services.ProductAPI.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public List<Product> products { get; set; }
    }
}
