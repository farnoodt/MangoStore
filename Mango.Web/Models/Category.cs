using System.ComponentModel.DataAnnotations;


namespace Mango.Web.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 1000)]

        public int ParentId { get; set; }

        public List<Product> Products { get; set; }
    }
}
