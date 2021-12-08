using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;

        }
        public async Task<IActionResult> CategoryIndex()
        {
            List<CategoryDto> list = new();
            var response = await _categoryService.GetAllCategoriesAsync<ResponseDto>("access_token");
            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
