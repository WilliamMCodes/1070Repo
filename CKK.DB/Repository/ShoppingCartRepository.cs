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

        public int AddToCart(int id, Product item)
        {
            using(var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM ShoppingCartItems WHERE ShoppinCartId = @Id;";
                var results = connection.Query(sql, new { Id = id, ProductId = item.Id, Quantity = item.Quantity });
                if (results != null)
                {
                    foreach (var product in results)
                    {
                        if (product.ProductId == item.Id)
                        {
                            return Update(new ShoppingCartItem { ShoppingCartId = id, ProductId = item.Id, Quantity = item.Quantity + product.Quantity });
                        }
                    }
                }
                else
                {   
                    var shoppingCartItem = new ShoppingCartItem { ShoppingCartId = id, ProductId = item.Id, Quantity = item.Quantity };
                    return Add(shoppingCartItem);
                }
                
            }
            return 0;
        }

        public int RemoveItem(int shoppingCartId, Product product)
        {
            var sql = "DELETE FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId AND ProductId = @ProductId";
            using(var connection = _connectionFactory.GetConnection)
            {
                return connection.Execute(sql, new { ShoppingCartId = shoppingCartId, ProductId = product.Id });
            }
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
            var sql = "SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId AND NOT ProductId = 0";
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
            var sql = "UPDATE ShoppingCartItems SET Quantity = @Quantity WHERE ShoppingCartId = @ShoppingCartId" +
                "AND ProductId = @ProductId";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        public int GetNewShoppingCart()
        {
            int newId;
            var sql = "SELECT MAX(ShoppingCartId) FROM ShoppingCartItems";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var results = connection.QueryFirstOrDefault(sql);
                newId = (int)results + 1;
            }
            _ = Add(new ShoppingCartItem{ShoppingCartId = newId, ProductId = 0, Quantity = 0 });
            return newId;
        }
    }
}
