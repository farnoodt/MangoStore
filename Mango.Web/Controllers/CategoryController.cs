using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
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

        public async Task<IActionResult> CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryCreate(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryService.CreateCategoryAsync<ResponseDto>(categoryDto, "access_token");
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(CategoryIndex));
                }
            }
            return View(categoryDto);
        }

        public async Task<IActionResult> CategoryEdit(int CategoryId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _categoryService.GetCategoryByIdAsync<ResponseDto>(CategoryId, accessToken);
            if (response != null && response.IsSuccess)
            {
                CategoryDto model = JsonConvert.DeserializeObject<CategoryDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryEdit(CategoryDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _categoryService.UpdateCategoryAsync<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(CategoryIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> CategoryDelete(int CategoryId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _categoryService.GetCategoryByIdAsync<ResponseDto>(CategoryId);
            if (response != null && response.IsSuccess)
            {
                CategoryDto model = JsonConvert.DeserializeObject<CategoryDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryDelete(CategoryDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _categoryService.DeleteCategoryAsync<ResponseDto>(model.CategoryId, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(CategoryIndex));
                }
            }
            return View(model);
        }
    }
}
