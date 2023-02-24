using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetByName(string name);
        Task<List<Product>> GetAll(int orderOption);
    }
}
