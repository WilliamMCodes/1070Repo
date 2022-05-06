using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Product :Entity
    {
        public decimal Price { get; set; }
        public Product(int id, string name, decimal price) : base(id, name)
        {
            Price = price;
        }
        
        
        
    }
}
