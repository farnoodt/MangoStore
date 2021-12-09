using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> CategoryCreate(CategoryDto categoryDto)
        {

            List<CategoryDto> list = new();
            var response = await _categoryService.GetAllCategoriesAsync<ResponseDto>("access_token");
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Result));
            }

            var CategoryList = (from category in list
                                select new SelectListItem()
                                {
                                    Text = category.Name,
                                    Value = category.CategoryId.ToString()
                                }).ToList();

            CategoryList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.ListofCategory = CategoryList;

            
            return View();
        }
    }
}
