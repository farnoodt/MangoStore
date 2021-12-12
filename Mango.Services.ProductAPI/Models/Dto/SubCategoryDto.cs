using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductAPI.Models.Dto
{
    public class SubCategoryDto
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public List<Product> products { get; set; }
    }
}
