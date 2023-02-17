using CKK.DB.Interfaces;
using CKK.DB.Repository;
using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Dynamic;
using Microsoft.VisualBasic;
using System.ComponentModel.Design;
using System.Linq;
using CKK.Logic.Exceptions;

namespace CKK.DB.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IConnectionFactory Conn)
        {
            Products = new ProductRepository(Conn);
            Orders = new OrderRepository(Conn);
            ShoppingCarts = new ShoppingCartRepository(Conn);
            SetCustomer(Conn);
        }
        public IProductRepository Products { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IShoppingCartRepository ShoppingCarts { get; set; }
        internal Customer Customer { get; set; }
        internal void CompleteCheckout()
        {
            Orders.Add(new Order { CustomerId = Customer.Id, ShoppingCartId = Customer.ShoppingCartId, OrderNumber = GenerateOrderNumber() } );
            foreach (var item in ShoppingCarts.GetProducts(Customer.ShoppingCartId))
            {
                Products.Update(new Product
                {
                    Id = item.ProductId,
                    Price = Products.GetbyId(item.ProductId).Price,
                    Name = Products.GetbyId(item.ProductId).Name,
                    Quantity = Products.GetbyId(item.ProductId).Quantity - item.Quantity
                });
            }
            Customer.ShoppingCartId = 0;
        }

        internal string GenerateOrderNumber()
        {
            Random rnd = new Random();
            return $"{DateAndTime.Year(DateTime.Now)}{rnd.Next(1000000):D6}{DateAndTime.Day(DateTime.Today):D2}" +
                $"{ShoppingCarts.GetProducts(Customer.ShoppingCartId).Count:D3}";
        }

        internal int AddItemToCart(Product product)
        {
            if (Customer.ShoppingCartId == 0)
            {
                Customer.ShoppingCartId = ShoppingCarts.GetNewShoppingCart();
            }
            return ShoppingCarts.AddToCart(Customer.ShoppingCartId, product);
        }
        internal int RemoveItemFromCart(Product product)
        {
            var results = 
                from item in ShoppingCarts.GetProducts(Customer.ShoppingCartId)
                where item.ProductId == product.Id
                select item;
                
            if (product.Quantity >= results.ToList()[0].Quantity)
            {
                return ShoppingCarts.RemoveItem(Customer.ShoppingCartId, product);
            }
            else
            {
                return ShoppingCarts.Update(new ShoppingCartItem 
                { 
                    ShoppingCartId = Customer.ShoppingCartId, 
                    ProductId = product.Id, 
                    Quantity = results.ToList()[0].Quantity - product.Quantity 
                });
            }
        }

        internal void SetCustomer(IConnectionFactory conn)
        {
            //For the sake of testing and demonstration for module 4 customer will default to CustomerId = 1
            Customer = new Customer { Id = 1, Address = "111 Somestreet City,ST zcode", Name = "Johnny Debug", ShoppingCartId = 0 };
        }
        public string GetCustomerName()
        {
            return Customer.Name;
        }
    }
}
