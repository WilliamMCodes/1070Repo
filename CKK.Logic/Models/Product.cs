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
        private decimal price;
        public Product(int id = 10101011, string name = "Thing-a-mabob", decimal price = 1.00M) : base(id, name)
        {
            Price = price;
        }
        
        public decimal Price
        {
            get => price;

            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price", $"{value:C} is not a valid price.");
                }
                else
                {
                    price = value;
                }
            }

        }   
        
    }
}
