
namespace Mango.Services.ShoppingCart.Models
{
    public class Cart
    {
        public CartHeader cartHeader { get; set; }
        public IEnumerable<CartDetails> CartDetails{ get; set; }
    }
}
