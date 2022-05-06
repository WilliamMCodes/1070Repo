using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
     public class Store :  Entity
    {
        private List<StoreItem> _storeInventory;

        public Store(int id = 11111111, string name = "New Store") : base(id, name)
        {
            _storeInventory = new List<StoreItem>();
        }
        public Store(List<StoreItem> inventory, int id = 11111111, string name = "New Store") : base(id, name)
        {
            _storeInventory = inventory;
        }

        public StoreItem AddStoreItem(Product prod, int quantity = 1)
        {
            if (quantity > 0)
            {
                
                if(FindStoreItemById(prod.Id) == null)
                {
                    var targetItem = new StoreItem(prod, quantity);
                    _storeInventory.Add(targetItem);
                    return targetItem;
                }
                else
                {
                    FindStoreItemById(prod.Id).Quantity = FindStoreItemById(prod.Id).Quantity + quantity;
                    return FindStoreItemById(prod.Id);
                }
            }

            return null;
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (quantity > 0)
            {
                var item = FindStoreItemById(id);
                if (item != null)
                {
                    item.Quantity = item.Quantity - quantity;
                    if (item.Quantity < 0)
                    {
                        item.Quantity = 0;
                    }

                    return item;
                }
            }
            

            return null;
        }

        public List<StoreItem> GetStoreItems()
        {
            return _storeInventory;
        }

        public StoreItem FindStoreItemById(int id)
        {
            var targetItem =
                from item in _storeInventory
                where item.Product.Id == id
                select item;

            if (targetItem.Any())
            {
                return targetItem.Single();
            }

            return null;
        }
    }
}
