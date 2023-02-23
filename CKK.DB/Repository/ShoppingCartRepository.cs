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
                var sql = "SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = @Id;";
                var results = connection.Query(sql, new { Id = id, ProductId = item.Id, Quantity = item.Quantity });
                if (results.AsList().Count > 1 )
                {
                    foreach (var product in results)
                    {
                        if (product.ProductId == item.Id)
                        {
                            return Update(new ShoppingCartItem { ShoppingCartId = id, ProductId = item.Id, Quantity = item.Quantity + product.Quantity });
                        }
                    }
                    var shoppingCartItem = new ShoppingCartItem { ShoppingCartId = id, ProductId = item.Id, Quantity = item.Quantity };
                    return Add(shoppingCartItem);
                }
                else
                {   
                    var shoppingCartItem = new ShoppingCartItem { ShoppingCartId = id, ProductId = item.Id, Quantity = item.Quantity };
                    return Add(shoppingCartItem);
                }
                
            }
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
                List<ShoppingCartItem> cartItems = new List<ShoppingCartItem>();
                var results = connection.Query(sql, new{ShoppingCartId = shoppingCartId});
                foreach (var item in results)
                {
                    cartItems.Add(new ShoppingCartItem { ShoppingCartId=item.Id, ProductId=item.Id, Quantity = item.Quantity });
                }
                return (List<ShoppingCartItem>)cartItems;
            }
        }

        public decimal GetTotal(int shoppingCartId)
        {
            decimal total = 0;
            List<ShoppingCartItem> items = GetProducts(shoppingCartId);
            using(var connection = _connectionFactory.GetConnection)
            {
                decimal productPrice;
                string sql;
                foreach (ShoppingCartItem item in items)
                {
                    sql = "SELECT Price FROM Products WHERE Id = @Id;";
                    productPrice = (connection.QuerySingleOrDefault(sql, new { Id = item.ProductId }) == null) ? 0M :
                        connection.QuerySingleOrDefault(sql, new { Id = item.ProductId });

                    total += productPrice * item.Quantity;
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
            var sql = "SELECT MAX(ShoppingCartId) As Id FROM ShoppingCartItems";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var results = connection.QueryFirstOrDefault(sql);
                if (results.Id == null)
                {
                    newId = 1;
                }
                else
                {
                    newId = results.Id + 1;
                }
            }
            _ = Add(new ShoppingCartItem{ShoppingCartId = newId, ProductId = 0, Quantity = 0 });
            return newId;
        }
    }
}
