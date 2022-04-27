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

        public ShoppingCartItem  AddProduct(Product prod, int quantity)
        {
            ShoppingCartItem targetItem = new ShoppingCartItem(prod, quantity);
            if (quantity <= 0)
            {
                return null;
            }

            var itemInCart =
                from item in _shoppingCartItems
                where item.GetProduct() == targetItem.GetProduct()
                select _shoppingCartItems.IndexOf(item);

            if (itemInCart.Any())
            {
                _shoppingCartItems[itemInCart.Single()].SetQuantity(_shoppingCartItems[itemInCart.Single()].GetQuantity() + quantity);
                return _shoppingCartItems[itemInCart.Single()];
            }
            else
            {
                _shoppingCartItems.Add(new ShoppingCartItem(prod, quantity));
                return _shoppingCartItems[_shoppingCartItems.IndexOf(targetItem)];
            }
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            var targetItem =
                from item in _shoppingCartItems
                where item.GetProduct() == prod
                select _shoppingCartItems.IndexOf(item);

            if (targetItem.Any())
            {
                _shoppingCartItems[targetItem.Single()].SetQuantity(_shoppingCartItems[targetItem.Single()].GetQuantity() + 1);
                return _shoppingCartItems[targetItem.Single()];
            }
            else
            {
                _shoppingCartItems.Add(new ShoppingCartItem(prod, 1));
                return _shoppingCartItems.Last();
            }
        }

        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            if (quantity <= 0)
            {
                return null;
            }

            if(GetProductById(prod.GetId()) != null)
            {
                if (GetProductById(prod.GetId()).GetQuantity() > quantity)
                {
                    GetProductById(prod.GetId()).SetQuantity(GetProductById(prod.GetId()).GetQuantity() - quantity);
                    return GetProductById(prod.GetId());
                }
                else
                {
                    _shoppingCartItems.Remove(GetProductById(prod.GetId()));
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
