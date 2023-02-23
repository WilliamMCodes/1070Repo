using CKK.DB.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace CKK.DB.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public OrderRepository(IConnectionFactory conn)
        {
            _connectionFactory = conn;
        }
        public int Add(Order order)
        {
            var sql = "INSERT INTO Orders (OrderNumber,CustomerId,ShoppingCartId) VALUES (@OrderNumber,@CustomerId,@ShoppingCartId)";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql,order);
                return result;
            }
        }

        public int Delete(int id)
        {
            var sql  = "DELETE FROM Orders WHERE OrderId = @OrderId";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, new {OrderId = id} );
                return result;
            }
        }

        public List<Order> GetAll()
        {
            var sql = "SELECT * FROM Orders";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Query(sql);
                List<Order> orders = new List<Order>();
                foreach(var item in result)
                {
                    orders.Add(new Order { CustomerId = item.CustomerId, OrderId = item.OrderId, 
                        OrderNumber = item.OrderNumber, ShoppingCartId = item.ShoppingCartId });
                }
                return orders;
            }
        }

        public Order GetbyId(int id)
        {
            var sql = "SELECT * FROM Orders WHERE OrderId = @OrderId";
            using( var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.QuerySingleOrDefault(sql, new {OrderId = id});
                return new Order { CustomerId = result.CustomerId, OrderId = result.OrderId, 
                    OrderNumber = result.OrderNumber, ShoppingCartId = result.ShoppingCartId};
            }
        }

        public List<Order> GetOrderByCustomerId(int id)
        {
            var sql = "SELECT * FROM Orders WHERE CustomerId = @CustomerId";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Query(sql, new {CustomerId = id});
                List<Order> orders = new List<Order>();
                foreach (var item in result)
                {
                    orders.Add(new Order
                    {
                        CustomerId = item.CustomerId,
                        OrderId = item.OrderId,
                        OrderNumber = item.OrderNumber,
                        ShoppingCartId = item.ShoppingCartId
                    });
                }
                return orders;
            }
        }

        public int Update(Order order)
        {
            var sql = "UPDATE Orders SET OrderNumber = @OrderNumber, CustomerId = @CustomerId, ShoppingCartId = @ShoppingCartId WHERE OderId = @OrderId";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, order);
                return result;
            }
        }
    }
}
