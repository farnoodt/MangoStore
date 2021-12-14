using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Mango.Web.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _CategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService CategoryService)
        {
            this._subCategoryService = subCategoryService;
            this._CategoryService = CategoryService;
        }
        public async Task<IActionResult> SubCategoryIndex()
        {
            List<SubCategoryDto> list = new();
            var _response = await _subCategoryService.GetAllSubCategoriesAsync<ResponseDto>("access_token");
            if(_response.IsSuccess && _response.Result != null)
            {
               list= JsonConvert.DeserializeObject<List<SubCategoryDto>>(Convert.ToString(_response.Result));
            }
            return View(list);
        }


        public async Task<IActionResult> SubCategoryCreate()
        {
            List<CategoryDto> list = new();
            var _response = await _CategoryService.GetAllCategoriesAsync<ResponseDto>("access_token");
            if (_response.IsSuccess && _response.Result != null)
            {
                list = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(_response.Result));
            }
            ViewBag.ListOfCategory = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubCategoryCreate(SubCategoryDto subcategoryDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _subCategoryService.CreateSubCategoryAsync<ResponseDto>(subcategoryDto, "access_token");
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(SubCategoryIndex));
                }
            }
            return View(subcategoryDto);
        }

        public async Task<IActionResult> SubCategoryEdit(int subCategoryId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            List<CategoryDto> list = new();
            var CatRes = await _CategoryService.GetAllCategoriesAsync<ResponseDto>("access_token");
            if (CatRes.IsSuccess && CatRes.Result != null)
            {
                list = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(CatRes.Result));
            }
            ViewBag.ListOfCategory = list;

            var response = await _subCategoryService.GetSubCategoryByIdAsync<ResponseDto>(subCategoryId, accessToken);
            
            if (response != null && response.IsSuccess)
            {
                SubCategoryDto model = JsonConvert.DeserializeObject<SubCategoryDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubCategoryEdit(SubCategoryDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _subCategoryService.UpdateSubCategoryAsync<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(SubCategoryIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> SubCategoryDelete(int subCategoryId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _subCategoryService.GetSubCategoryByIdAsync<ResponseDto>(subCategoryId);
            if (response != null && response.IsSuccess)
            {
                SubCategoryDto model = JsonConvert.DeserializeObject<SubCategoryDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubCategoryDelete(SubCategoryDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _subCategoryService.DeleteSubCategoryAsync<ResponseDto>(model.SubCategoryId, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(SubCategoryIndex));
                }
            }
            return View(model);
        }
    }
}
