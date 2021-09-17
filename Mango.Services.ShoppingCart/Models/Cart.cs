
namespace Mango.Services.ShoppingCartAPI.Models
{
    public class Cart
    {
        public CartHeader cartHeader { get; set; }
        public IEnumerable<CartDetails> CartDetails{ get; set; }
    }
}
