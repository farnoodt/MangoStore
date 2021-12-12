using System.ComponentModel.DataAnnotations;


namespace Mango.Web.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }

        public List<SubCategory> Products { get; set; }
    }
}
