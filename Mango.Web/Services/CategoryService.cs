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
        public async Task<T> CreateCategoryAsync<T>(CategoryDto categoryDto)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = categoryDto,
                Url = SD.CategoryAPIBase + "/api/categories",
                AccessToken = ""
            });
        }

        public Task<T> DeleteCategoryAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllCategoriesAsync<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetCategoryByIdAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateCategoryAsync<T>(CategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
