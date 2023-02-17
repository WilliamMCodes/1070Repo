using System;
using System.Collections.Generic;
using System.Text;
using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetByName(string name);
        List<Product> GetAll(int orderOption);
    }
}
