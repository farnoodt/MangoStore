using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;


namespace Mango.Web.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CategoryService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            this._clientFactory = clientFactory;
        }
        public async Task<T> CreateCategoryAsync<T>(CategoryDto categoryDto, string token = null)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = categoryDto,
                Url = SD.ProductAPIBase + "/api/categories",
                AccessToken = token
            });
        }

        public async Task<T> DeleteCategoryAsync<T>(int id, string token = null)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/categories/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetAllCategoriesAsync<T>(string token = null)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/categories" ,
                AccessToken = ""
            });
        }

        public async Task<T> GetCategoryByIdAsync<T>(int id, string token = null)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/categories/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateCategoryAsync<T>(CategoryDto categoryDto, string token = null)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.ProductAPIBase + "/api/categories" ,
                Data = categoryDto,
                AccessToken = ""
            });
        }

        //public async Task<CategoryViewModelDto> GetAllCategoriesDDAsync<T>(string token = null)
        //{
        //    var CategorySelectListItem = await GetCategories<ResponseDto>();
        //    var category = new CategoryViewModelDto()
        //    {
               
        //        Categories = CategorySelectListItem 
        //    };
            
        //    return category;
        //}

        //public async Task<IEnumerable<SelectListItem>> GetCategories<T>()
        //{
        //    List<CategoryDto> list = new();
        //    ResponseDto response = await this.SendAsync<ResponseDto>(new Models.ApiRequest()
        //    {
        //        ApiType = SD.ApiType.GET,
        //        Url = SD.ProductAPIBase + "/api/categories",
        //        AccessToken = ""
        //    });

        //    if (response != null && response.IsSuccess)
        //    {
        //        list = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Result));
        //    }

        //    List<SelectListItem> CategoryList = list.OrderBy(x=>x.Name)
        //                                         .Select( x=> new SelectListItem
        //                                         {
        //                                             Text = x.Name,
        //                                             Value = x.CategoryId.ToString()
        //                                         }).ToList();

        //    CategoryList.Insert(0, new SelectListItem()
        //    {
        //        Text = "----Select----",
        //        Value = string.Empty
        //    });

        //    return new SelectList( CategoryList, "Value", "Text") ;
        //}
    }
}
