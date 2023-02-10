using CKK.DB.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace CKK.DB.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ShoppingCartRepository(IConnectionFactory conn)
        {
            _connectionFactory = conn;
        }
        public int Add(ShoppingCartItem entity)
        {
            var sql = "INSERT INTO ShoppingCartItems (ShoppingCartId, ProductId, Quantity) VALUES (@ShoppingCartId, @ProductId, @Quantity)";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        public ShoppingCartItem AddToCart(ShoppingCartItem item)
        {
            using(var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM ShoppingCartItems WHERE ShoppinCartId = @ShoppingCartId;";
                var results = connection.Query(sql, new { ShoppingCartId = item.ShoppingCartId });
                if (results != null)
                {
                    foreach (var product in results)
                    {
                        if ((ShoppingCartItem)product.ProductId = item.ProductId)
                        {
                            return new ShoppingCartItem { ShoppingCartId = item.ShoppingCartId, ProductId = item.ProductId, Quantity = item.Quantity + product.Quantity };
                        }
                    }
                }
                else
                {   
                    return item;
                }
                
            }
            
            using(var connection = _connectionFactory.GetConnection)
            return null;
        }

        public int ClearCart(int shoppingCartId)
        {
            var sql = "DELETE FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var results = connection.Execute(sql, new {ShoppingCartId = shoppingCartId});
                return results;
            }
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            var sql = "SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var results = connection.Query(sql, new{ShoppingCartId = shoppingCartId});
                return (List<ShoppingCartItem>)results;
            }
        }

        public decimal GetTotal(int shoppingCartId)
        {
            decimal total = 0;
            List<ShoppingCartItem> items = GetProducts(shoppingCartId);
            using(var connection = _connectionFactory.GetConnection)
            {
                Product product;
                string sql;
                foreach (ShoppingCartItem item in items)
                {
                    sql = "SELECT Price FROM Products WHERE Id = @Id;";
                    product = (Product)connection.Query(sql, new { Id = item.ProductId });
                    total += product.Price * item.Quantity;
                }
                return total;
            }
        }

        public int Update(ShoppingCartItem entity)
        {
            var sql = "UPDATE ShoppingCartItems SET ShoppingCartId = @ShoppingCartId, ProductId = @ProductId, Quantity = @Quantity WHERE Id = @Id";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }
    }
}
