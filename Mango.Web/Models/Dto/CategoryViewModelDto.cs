using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;


namespace Mango.Web.Models.Dto
{
    public class CategoryViewModelDto
    {
        
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
