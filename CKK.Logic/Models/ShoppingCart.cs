using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        public Customer Customer { get; set; }
        public List<ShoppingCartItem> Products { get; set; }

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
            Products = new List<ShoppingCartItem>();
        }

        public int GetCustomerId()
        {
            return Customer.Id;
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity = 1)
        {
            if (quantity <= 0)
            {
                throw new InventoryItemStockTooLowException(quantity);
            }
            if (GetProductById(prod.Id) == null)
            {
                var targetItem = new ShoppingCartItem(prod, quantity);
                Products.Add(targetItem);
                return targetItem;
            }
            else
            {
                GetProductById(prod.Id).Quantity = GetProductById(prod.Id).Quantity + quantity;
                return GetProductById(prod.Id);
            }
        }

        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("quantity", $"{quantity} is not a valid amount to reduce quantity by.");
            }

            if (GetProductById(id) != null)
            {
                if (GetProductById(id).Quantity > quantity)
                {
                    GetProductById(id).Quantity = GetProductById(id).Quantity - quantity;
                    return GetProductById(id);
                }
                else
                {
                    var storeItem = GetProductById(id);
                    Products.Remove(GetProductById(id));
                    storeItem.Quantity = 0;
                    return storeItem;
                }
            }
            throw new ProductDoesNotExistException(id);
        }

        public void EmptyCart()
        {
            Products.Clear();
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if(id < 0)
            {
                throw new InvalidIdException(id);
            }
            var targetItem =
                from item in Products
                where item.Product.Id == id
                select Products.IndexOf(item);
            if (targetItem.Any())
            {
                return Products[targetItem.Single()];
            }

            return null;
        }

        public decimal GetTotal()
        {
            decimal total = 0.0M;
            var itemCosts =
                from item in Products
                let cost = item.Product.Price * item.Quantity
                select cost;

            foreach (decimal cost in itemCosts)
            {
                total += cost;
            }

            return total;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }
    }
}
