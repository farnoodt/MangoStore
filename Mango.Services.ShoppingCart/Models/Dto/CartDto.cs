
namespace Mango.Services.ShoppingCart.Models.Dto
{
    public class CartDto
    {
        public CartHeaderDto cartHeader { get; set; }
        public IEnumerable<CratDetailsDto> CartDetails { get; set; }
    }
}
