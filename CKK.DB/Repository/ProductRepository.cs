using CKK.DB.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace CKK.DB.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ProductRepository(IConnectionFactory conn)
        {
            _connectionFactory = conn;
        }
        public int Add(Product entity)
        {
            var sql = "INSERT INTO Products (Price, Quantity, Name) VALUES (@Price,@Quantity, @Name)";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }

        public int Delete(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, new {Id = id});
                return result;
            }
        }

        public List<Product> GetAll()
        {
            var sql = "SELECT * FROM Products";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var list = connection.Query(sql);
                return (List<Product>)list;
            }
        }

        public List<Product> GetAll(int orderOption)
        {
            string option = "Id";
            if (orderOption == 1)
            {
                option = "Price";
            }
            else if(orderOption == 2)
            {
                option = "Quantity";
            }
            
            var sql = "SELECT * FROM Products OrderBy " + option;
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var list = connection.Query(sql);
                return (List<Product>)list;
            }
        }

        public Product GetbyId(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var product = connection.QuerySingleOrDefault(sql, new {Id = id});
                return product;
            }
        }

        public List<Product> GetByName(string name)
        {
            var sql = "SELECT * FROM Products WHERE Name LIKE @Name";
            using ( var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Query(sql, new {Name = "*" + name + "*" });
                return  (List<Product>)result;
            }
        }

        public int Update(Product entity)
        {
            var sql = "UPDATE Products SET Price = @Price, Quantity = @Quantity, Name = @Name WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = connection.Execute(sql, entity);
                return result;
            }
        }
    }
}
