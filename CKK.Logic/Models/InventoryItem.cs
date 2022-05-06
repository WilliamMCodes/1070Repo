using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public abstract class InventoryItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public InventoryItem(Product prod, int quantity)
        {
            Product = prod;
            Quantity = quantity;
        }
    }
}
