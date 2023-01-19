using System;
using System.Collections.Generic;
using System.Text;
using CKK.Logic.Models;

namespace CKK.DB.Interfaces
{
    internal interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetByName(string name);
    }
}
