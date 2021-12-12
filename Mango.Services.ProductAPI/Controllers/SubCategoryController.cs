using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/subcategories")]
    public class SubCategoryController : ControllerBase
    {
        protected ResponseDto _response;
        private ISubCategoryRepository _subcategoryRepository;


        public SubCategoryController(ISubCategoryRepository subcategoryRepository)
        {
            this._subcategoryRepository = subcategoryRepository;
            this._response = new ResponseDto();
        }


        [HttpGet()]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<SubCategoryDto> subCategory = await _subcategoryRepository.GetSubCategories();
                _response.Result = subCategory;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{subcategoryId}")]
        public async Task<object> Get(int subcategoryId)
        {
            try
            {
                SubCategoryDto subCategory = await _subcategoryRepository.GetSubCategoryById(subcategoryId);
                _response.Result = subCategory;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost()]
        public async Task<object> Post([FromBody] SubCategoryDto subcategoryDto)
        {
            try
            {
                SubCategoryDto model = await _subcategoryRepository.CreateOrUpdateCategory(subcategoryDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }

        [HttpPut()]
        public async Task<object> Put([FromBody] SubCategoryDto subcategoryDto)
        {
            try
            {
                SubCategoryDto model = await _subcategoryRepository.CreateOrUpdateCategory(subcategoryDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }

        [HttpDelete("{subcategoryId}")]
        public async Task<object> Delete(int subcategoryId)
        {
            try
            {
                bool IsSuccess = await _subcategoryRepository.DeleteCategory(subcategoryId);
                _response.Result = IsSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;
        }
    }
}
