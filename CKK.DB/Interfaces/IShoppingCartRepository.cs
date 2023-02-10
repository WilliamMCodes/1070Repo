using System;
using System.Collections.Generic;
using System.Text;
using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCartItem AddToCart(ShoppingCartItem item);
        int ClearCart(int shoppingCartId);
        decimal GetTotal(int shoppingCartId);
        List<ShoppingCartItem> GetProducts(int shoppingCartId);
        int Update(ShoppingCartItem entity);
        int Add(ShoppingCartItem entity);
    }
}
