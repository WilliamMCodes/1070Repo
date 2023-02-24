using CKK.DB.Interfaces;
using CKK.Logic.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ProductRepository(IConnectionFactory conn)
        {
            _connectionFactory = conn;
        }
        public async Task<int> Add(Product entity)
        {
            var sql = "INSERT INTO Products (Price, Quantity, Name) VALUES (@Price, @Quantity, @Name)";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new {Id = id});
                return result;
            }
        }

        public async Task<List<Product>> GetAll()
        {
            var sql = "SELECT * FROM Products";
            using (var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var list = await connection.QueryAsync(sql);
                List<Product> products = new List<Product>();
                foreach (var item in list)
                {
                    products.Add(new Product { Id = item.Id, Name = item.Name, Price = item.Price, Quantity = item.Quantity});
                }
                return products;
            }
        }

        public async Task<List<Product>> GetAll(int orderOption)
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
                var list = await connection.QueryAsync(sql);
                List<Product> products = new List<Product>();
                foreach (var item in list)
                {
                    products.Add(new Product { Id = item.Id, Name = item.Name, Price = item.Price, Quantity = item.Quantity });
                }
                return products;
            }
        }

        public async Task<Product> GetbyId(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            using(var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var product = await connection.QuerySingleOrDefaultAsync(sql, new {Id = id});
                return new Product { Id = product.Id, Name = product.Name, Price = product.Price, Quantity = product.Quantity };
            }
        }

        public async Task<List<Product>> GetByName(string name)
        {
            var sql = "SELECT * FROM Products WHERE Name LIKE @Name";
            using ( var connection = _connectionFactory.GetConnection)
            {
                connection.Open();
                var result = await connection.QueryAsync(sql, new {Name = "*" + name + "*" });
                List<Product> products = new List<Product>();
                foreach (var item in result)
                {
                    products.Add(new Product { Id = item.Id, Name = item.Name, Price = item.Price, Quantity = item.Quantity });
                }
                return products;
            }
        }

        public async Task<int> Update(Product entity)
        {
            if (entity.Id != 0)
            {
                var sql = "UPDATE Products SET Price = @Price, Quantity = @Quantity, Name = @Name WHERE Id = @Id";
                using (var connection = _connectionFactory.GetConnection)
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, entity);
                    return result;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
