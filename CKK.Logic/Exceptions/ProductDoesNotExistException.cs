using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace CKK.Logic.Exceptions
{
    public class ProductDoesNotExistException: Exception
    {
        public override string Message { get; }
        public ProductDoesNotExistException(int id)
        {
            Message = $"Product with item number: {id}, could not be found.";
        }
        public ProductDoesNotExistException(Product product)
        {
            Message = $"{product.Name} with item number: {product.Id}, could not be found.";
        }
    }
}
