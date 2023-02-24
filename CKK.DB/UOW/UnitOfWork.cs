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
        public Customer Customer { get; set; }
        public string CompleteCheckout()
        {
            var orderNumber = GenerateOrderNumber().Result;
            Orders.Add(new Order { CustomerId = Customer.Id, ShoppingCartId = Customer.ShoppingCartId, OrderNumber = orderNumber } );
            foreach (var item in ShoppingCarts.GetProducts(Customer.ShoppingCartId).Result)
            {
                Products.Update(new Product
                {
                    Id = item.ProductId,
                    Price = Products.GetbyId(item.ProductId).Result.Price,
                    Name = Products.GetbyId(item.ProductId).Result.Name,
                    Quantity = Products.GetbyId(item.ProductId).Result.Quantity - item.Quantity
                });
            }
            Customer.ShoppingCartId = 0;
            return orderNumber;
        }

        public async Task<string> GenerateOrderNumber()
        {
            Random rnd = new Random();
            return $"{DateAndTime.Year(DateTime.Now)}{rnd.Next(1000000):D6}{DateAndTime.Day(DateTime.Today):D2}" +
                $"{ShoppingCarts.GetProducts(Customer.ShoppingCartId).Result.Count:D3}";
        }

        public int AddItemToCart(Product product)
        {
            if (Customer.ShoppingCartId == 0)
            {
                Customer.ShoppingCartId = ShoppingCarts.GetNewShoppingCart().Result;
            }
            return ShoppingCarts.AddToCart(Customer.ShoppingCartId, product).Result;
        }
        public int RemoveItemFromCart(Product product)
        {
            var results = 
                from item in ShoppingCarts.GetProducts(Customer.ShoppingCartId).Result
                where item.ProductId == product.Id
                select item;
                
            if (product.Quantity >= results.ToList()[0].Quantity)
            {
                return ShoppingCarts.RemoveItem(Customer.ShoppingCartId, product).Result;
            }
            else
            {
                return ShoppingCarts.Update(new ShoppingCartItem 
                { 
                    ShoppingCartId = Customer.ShoppingCartId, 
                    ProductId = product.Id, 
                    Quantity = results.ToList()[0].Quantity - product.Quantity 
                }).Result;
            }
        }

        public void SetCustomer(IConnectionFactory conn)
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
