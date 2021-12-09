using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models
{
    public class CategoryViewModel
    {
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
