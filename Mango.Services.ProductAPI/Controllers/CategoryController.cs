using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        protected ResponseDto _response;
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
            this._response = new ResponseDto();
        }

        [HttpGet()]
        public async Task<object> Get()
        {
            try 
            {
                IEnumerable<CategoryDto> categories = await _categoryRepository.GetCategories();
                _response.Result = categories;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{CategoryId}")]
        public async Task<object> Get(int CategoryId)
        {
            try
            {
                CategoryDto category = await _categoryRepository.GetCategoryById(CategoryId);
                _response.Result = category;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost()]
        public async Task<object> Post([FromBody] CategoryDto categoryDto)
        {
            try
            {
                CategoryDto model = await _categoryRepository.CreateOrUpdateCategory(categoryDto);
                _response.Result = model;
            }
            catch(Exception Ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { Ex.Message };
            }
            return _response;
        }

        [HttpPut()]
        public async Task<object> Put([FromBody] CategoryDto categoryDto)
        {
            try
            {
                CategoryDto model = await _categoryRepository.CreateOrUpdateCategory(categoryDto);
                _response.Result = model;
            }
            catch (Exception Ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { Ex.Message };
            }
            return _response;
        }

        [HttpDelete("{categoryId}")]
        public async Task<object> Delete(int categoryId)
        {
            try
            {
                bool isSuccess = await _categoryRepository.DeleteCategory(categoryId);
                _response.Result = isSuccess;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }
    }
}
