using CKK.DB.Interfaces;
using CKK.DB.Repository;
using CKK.DB.UOW;
namespace CKK.Online.Models
{
    public class Store
    {
        public IUnitOfWork StoreFront { get; set; }
        public CustomerCart ShoppingCart { get; set; }
        public Store(UnitOfWork UOW)
        {
            StoreFront = UOW;
            ShoppingCart = new CustomerCart();
            ShoppingCart.CartItems = StoreFront.ShoppingCarts.GetProducts(StoreFront.Customer.ShoppingCartId).Result;
        }

        public void RefreshCart(CustomerCart cart)
        {
            cart.CartItems.Clear();
            cart.CartItems = StoreFront.ShoppingCarts.GetProducts(StoreFront.Customer.ShoppingCartId).Result;
            foreach (var item in cart.CartItems)
            {
                item.Product = StoreFront.Products.GetbyId(item.ProductId).Result;
            }
            cart.Total = StoreFront.ShoppingCarts.GetTotal(StoreFront.Customer.ShoppingCartId).Result;
        }
    }
}
