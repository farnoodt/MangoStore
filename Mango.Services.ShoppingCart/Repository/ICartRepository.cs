using Mango.Services.ShoppingCart.Models.Dto;

namespace Mango.Services.ShoppingCart.Repository
{
    public interface ICartRepository
    {
        Task<CartDto> GetCartByUserId(string userId);
        Task<CartDto> CreateUpdateCart(CartDto cartDto);
        Task<bool> RemoveFromCart(int cartDetailsId);
        Task<bool> ClearCrat(string userId);
    }
}
