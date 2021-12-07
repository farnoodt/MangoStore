using Mango.Web.Models.Dto;
using Mango.Web.Services;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        public CartController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }
        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartDtoBasedOnLoggedinUser());
        }

        private async Task<CartDto> LoadCartDtoBasedOnLoggedinUser()
        {
            var userId = User.Claims.Where(u => u.Type == "sid")?.FirstOrDefault().Value;
            var accessToken = await HttpContext.GetTokenAsync("access-token");
            var response = await _cartService.GetCartByUserIdAsync<ResponseDto>(userId, accessToken);

            CartDto cartDto = new();
            if(response!=null && response.IsSuccess)
            {
                cartDto = JsonConvert.DeserializeObject<CartDto>(Convert.ToString(response.Result));
            }

            if (cartDto.cartHeader != null)
            {
                foreach(var detail in cartDto.CartDetails)
                {
                    cartDto.cartHeader.Ordertotal += (detail.Product.Price * detail.Product.Count); 
                }
            }

            return cartDto;
        }
    }
}
