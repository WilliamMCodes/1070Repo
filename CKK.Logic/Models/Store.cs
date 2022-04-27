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

        public StoreItem AddStoreItem(Product prod, int quantity = 1)
        {
            if (quantity > 0)
            {
                
                if(FindStoreItemById(prod.GetId()) == null)
                {
                    var targetItem = new StoreItem(prod, quantity);
                    _storeInventory.Add(targetItem);
                    return targetItem;
                }
                else
                {
                    FindStoreItemById(prod.GetId()).SetQuantity(FindStoreItemById(prod.GetId()).GetQuantity() + quantity);
                    return FindStoreItemById(prod.GetId());
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
            var targetItem =
                from item in _storeInventory
                where item.GetProduct().GetId() == id
                select item;

            if (targetItem.Any())
            {
                return targetItem.Single();
            }

            return null;
        }
    }
}
