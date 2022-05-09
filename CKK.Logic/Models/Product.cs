using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class Product :Entity
    {
        public decimal Price { get; set; }
        public Product(int id = 10101011, string name = "Thing-a-mabob", decimal price = 1.00M) : base(id, name)
        {
            Price = price;
        }
        
        
        
    }
}
