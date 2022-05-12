using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public abstract class InventoryItem
    {
        public InventoryItem(Product prod, int quantity)
        {
            Product = prod;
            Quantity = quantity;
        }

        public Product Product
        {
            get
            {
                return Product;
            }

            set => Product = value;
        }

        public int Quantity
        {
            get
            {
                return Quantity;
            }
            set
            {
                if(value < 0)
                {
                    throw new InventoryItemStockTooLowException(value);
                }

                Quantity = value;
            }
        }
    }
}
