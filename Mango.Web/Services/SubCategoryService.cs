using Mango.Web.Models.Dto;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class SubCategoryService : BaseService, ISubCategoryService
    {
        private readonly IHttpClientFactory _clientFactory;
        public SubCategoryService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            this._clientFactory = clientFactory;
        }

        public async Task<T> CreateSubCategoryAsync<T>(SubCategoryDto subcategoryDto, string token = null)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = subcategoryDto,
                Url = SD.ProductAPIBase + "/api/subcategories",
                AccessToken = token
            });
        }

        public async Task<T> DeleteSubCategoryAsync<T>(int id, string token = null)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/subcategories/"+ id,
                AccessToken = token
            });
        }

        public async Task<T> GetAllSubCategoriesAsync<T>(string token = null)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/subcategories",
                AccessToken = token
            });
        }

        public async Task<T> GetSubCategoryByIdAsync<T>(int id, string token = null)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/subcategories/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateSubCategoryAsync<T>(SubCategoryDto subcategoryDto, string token = null)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = subcategoryDto,
                Url = SD.ProductAPIBase + "/api/subcategories",
                AccessToken = token
            });
        }
    }
}
