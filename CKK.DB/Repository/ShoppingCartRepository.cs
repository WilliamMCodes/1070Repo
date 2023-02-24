using CKK.DB.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ShoppingCartRepository(IConnectionFactory conn)
        {
            _connectionFactory = conn;
        }
        public async Task<int> Add(ShoppingCartItem entity)
        {
            var sql = "INSERT INTO ShoppingCartItems (ShoppingCartId, ProductId, Quantity) VALUES (@ShoppingCartId, @ProductId, @Quantity)";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> AddToCart(int id, Product item)
        {
            using(var connection = _connectionFactory.GetConnection)
            {
                var sql = "SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = @Id;";
                var results = await connection.QueryAsync(sql, new { Id = id, ProductId = item.Id, Quantity = item.Quantity });
                if (results.AsList().Count > 1 )
                {
                    foreach (var product in results)
                    {
                        if (product.ProductId == item.Id)
                        {
                            return Update(new ShoppingCartItem { ShoppingCartId = id, ProductId = item.Id, Quantity = item.Quantity + product.Quantity }).Result;
                        }
                    }
                    var shoppingCartItem = new ShoppingCartItem { ShoppingCartId = id, ProductId = item.Id, Quantity = item.Quantity };
                    return Add(shoppingCartItem).Result;
                }
                else
                {   
                    var shoppingCartItem = new ShoppingCartItem { ShoppingCartId = id, ProductId = item.Id, Quantity = item.Quantity };
                    return Add(shoppingCartItem).Result;
                }
                
            }
        }

        public async Task<int> RemoveItem(int shoppingCartId, Product product)
        {
            var sql = "DELETE FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId AND ProductId = @ProductId";
            using(var connection = _connectionFactory.GetConnection)
            {
                return await connection.ExecuteAsync(sql, new { ShoppingCartId = shoppingCartId, ProductId = product.Id });
            }
        }

        public async Task<int> ClearCart(int shoppingCartId)
        {
            var sql = "DELETE FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var results = await connection.ExecuteAsync(sql, new {ShoppingCartId = shoppingCartId});
                return results;
            }
        }

        public async Task<List<ShoppingCartItem>> GetProducts(int shoppingCartId)
        {
            var sql = "SELECT * FROM ShoppingCartItems WHERE ShoppingCartId = @ShoppingCartId AND NOT ProductId = 0";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                List<ShoppingCartItem> cartItems = new List<ShoppingCartItem>();
                var results = await connection.QueryAsync(sql, new{ShoppingCartId = shoppingCartId});
                foreach (var item in results)
                {
                    cartItems.Add(new ShoppingCartItem { ShoppingCartId=item.Id, ProductId=item.ProductId, Quantity = item.Quantity });
                }
                return cartItems;
            }
        }

        public async Task<decimal> GetTotal(int shoppingCartId)
        {
            decimal total = 0;
            List<ShoppingCartItem> items = GetProducts(shoppingCartId).Result;
            using(var connection = _connectionFactory.GetConnection)
            {
                decimal productPrice;
                string sql;
                foreach (ShoppingCartItem item in items)
                {
                    sql = "SELECT Price FROM Products WHERE Id = @Id;";
                    productPrice = (await connection.QuerySingleOrDefaultAsync(sql, new { Id = item.ProductId }) == null) ? 0M :
                        await connection.QuerySingleOrDefaultAsync<decimal>(sql, new { Id = item.ProductId });

                    total += productPrice * item.Quantity;
                }
                return total;
            }
        }

        public async Task<int> Update(ShoppingCartItem entity)
        {
            var sql = "UPDATE ShoppingCartItems SET Quantity = @Quantity WHERE ShoppingCartId = @ShoppingCartId" +
                "AND ProductId = @ProductId";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> GetNewShoppingCart()
        {
            int newId;
            var sql = "SELECT MAX(ShoppingCartId) As Id FROM ShoppingCartItems";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var results = await connection.QueryFirstOrDefaultAsync(sql);
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

        public async Task<int> GetExistingCartIdForExample()
        {
            var sql = "SELECT MAX(ShoppingCartId) As Id FROM ShoppingCartItems";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var results = await connection.QueryFirstOrDefaultAsync(sql);
                return results.Id;
            }
        }
    }
}
