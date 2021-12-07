
namespace Mango.Web.Models.Dto
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public List<Product> Products { get; set; }
    }
}
