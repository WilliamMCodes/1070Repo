using System;
using System.Collections.Generic;
using System.Text;

namespace CKK.DB.Interfaces
{
    internal interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IShoppingCartRepository ShoppingCarts { get; }
    }
}
