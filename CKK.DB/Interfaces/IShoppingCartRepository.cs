using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<int> AddToCart(int id, Product item);
        Task<int> ClearCart(int shoppingCartId);
        Task<decimal> GetTotal(int shoppingCartId);
        Task<List<ShoppingCartItem>> GetProducts(int shoppingCartId);
        Task<int> Update(ShoppingCartItem entity);
        Task<int> Add(ShoppingCartItem entity);
        Task<int> RemoveItem(int shoppingCartId, Product product);

        Task<int> GetNewShoppingCart();

        Task<int> GetExistingCartIdForExample();
    }
}
