using CKK.Logic.Models;

namespace CKK.Online.Models
{
    public class CustomerCart
    {
        public List<ShoppingCartItem> CartItems { get; set; }
        public CustomerCart()
        {
            CartItems = new List<ShoppingCartItem>();
        }
    }
}
