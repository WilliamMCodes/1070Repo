using System;
using System.Collections.Generic;
using System.Text;
using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    public interface IShoppingCartRepository
    {
        int AddToCart(int id, Product item);
        int ClearCart(int shoppingCartId);
        decimal GetTotal(int shoppingCartId);
        List<ShoppingCartItem> GetProducts(int shoppingCartId);
        int Update(ShoppingCartItem entity);
        int Add(ShoppingCartItem entity);
        int RemoveItem(int shoppingCartId, Product product);
    }
}
