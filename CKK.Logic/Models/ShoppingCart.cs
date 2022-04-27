using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer _customer;
        private List<ShoppingCartItem> _shoppingCartItems;

        public ShoppingCart(Customer cust)
        {
            _customer = cust;
            _shoppingCartItems = new List<ShoppingCartItem>();
        }

        public int GetCustomerId()
        {
            return _customer.GetId();
        }

        public ShoppingCartItem  AddProduct(Product prod, int quantity = 1)
        {
            if (quantity <= 0)
            {
                return null;
            }
            if (GetProductById(prod.GetId()) == null)
            {
                var targetItem = new ShoppingCartItem(prod, quantity);
                _shoppingCartItems.Add(targetItem);
                return targetItem;
            }
            else
            {
                GetProductById(prod.GetId()).SetQuantity(GetProductById(prod.GetId()).GetQuantity() + quantity);
                return GetProductById(prod.GetId());
            }
        }

        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (quantity <= 0)
            {
                return null;
            }

            if(GetProductById(id) != null)
            {
                if (GetProductById(id).GetQuantity() > quantity)
                {
                    GetProductById(id).SetQuantity(GetProductById(id).GetQuantity() - quantity);
                    return GetProductById(id);
                }
                else
                {
                    var storeItem = GetProductById(id);
                    _shoppingCartItems.Remove(GetProductById(id));
                    storeItem.SetQuantity(0);
                    return storeItem;
                }
            }
            return null;
        }

        public void EmptyCart()
        {
            _shoppingCartItems.Clear();
        }

        public ShoppingCartItem GetProductById(int id)
        {
            var targetItem =
                from item in _shoppingCartItems
                where item.GetProduct().GetId() == id
                select _shoppingCartItems.IndexOf(item);
            if (targetItem.Any())
            {
                return _shoppingCartItems[targetItem.Single()];
            }

            return null;
        }

        public decimal GetTotal()
        {
            decimal total = 0.0M;
            var itemCosts =
                from item in _shoppingCartItems
                let cost = item.GetProduct().GetPrice() * item.GetQuantity()
                select cost;

            foreach (decimal cost in itemCosts)
            {
                total += cost;
            }

            return total;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return _shoppingCartItems;
        }
    }
}
