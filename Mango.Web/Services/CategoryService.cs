using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;

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
                Url = SD.CategoryAPIBase + "/api/categories",
                AccessToken = token
            });
        }

        public async Task<T> DeleteCategoryAsync<T>(int id, string token = null)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CategoryAPIBase + "/api/categories/" + id,
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
                Url = SD.CategoryAPIBase + "/api/categories/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateCategoryAsync<T>(CategoryDto categoryDto, string token = null)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.CategoryAPIBase + "/api/categories" ,
                Data = categoryDto,
                AccessToken = ""
            });
        }
    }
}
