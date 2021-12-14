

using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductAPI.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        [Required]
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public virtual List<Product> products { get; set; }
    }
}
