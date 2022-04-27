using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
     public class Store
    {
        private int _id;
        private string _name;
        private List<StoreItem> _storeInventory;

        public Store(int id = 11111111, string name = "New Store")
        {
            _storeInventory = new List<StoreItem>();
            _id = id;
            _name = name;
        }
        public Store(List<StoreItem> inventory, int id = 11111111, string name = "New Store")
        {
            _storeInventory = inventory;
            _id = id;
            _name = name;
        }

        public int GetId()
        {
            return _id;
        }
        public void SetId(int id)
        {
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if (quantity > 0)
            {
                StoreItem targetItem = new StoreItem(prod, quantity);
                if (_storeInventory.Contains(targetItem))
                {
                    foreach (StoreItem item in _storeInventory)
                    {
                        if (item.GetProduct().GetId() == prod.GetId())
                        {
                            item.SetQuantity(item.GetQuantity() + quantity);
                            return item;
                        }
                    }
                }
                else
                {
                    _storeInventory.Add(targetItem);
                    return _storeInventory[_storeInventory.IndexOf(targetItem)];
                }
            }

            return null;
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            foreach (StoreItem item in _storeInventory)
            {
                if (item.GetProduct().GetId() == id)
                {
                    item.SetQuantity(item.GetQuantity() - quantity);
                    if (item.GetQuantity() < 0)
                    {
                        item.SetQuantity(0);
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
            foreach( StoreItem item in _storeInventory)
            {
                if (item.GetProduct().GetId() == id)
                {
                    return item;
                }
            }

            return null;

        }
    }
}
