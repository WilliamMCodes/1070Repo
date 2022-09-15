using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;

namespace CKK.Logic.Models
{
    public class StoreItem : InventoryItem
    {
        public StoreItem(Product product, int quantity) : base(product, quantity)
        {

        }

        public override string ToString()
        {
            return $"Item#: {Product.Id,-20} Name: {Product.Name,-45} Price: {Product.Price,-20:C2} Quantity: {Quantity,-10}";
        }
    }
}
