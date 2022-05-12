using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
     public class Store :  Entity, IStore
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

            throw new InventoryItemStockTooLowException(quantity);
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("quantity", $"{quantity} is not a valid amount to reduce inventory by.");
            }

            var item = FindStoreItemById(id);
            if (item != null)
            {
                if(item.Quantity >= quantity)
                {
                    item.Quantity = item.Quantity - quantity;
                }
                else
                {
                    item.Quantity = 0;
                }
                return item;
            }

            throw new ProductDoesNotExistException(id);

        }

        public List<StoreItem> GetStoreItems()
        {
            return _storeInventory;
        }

        public StoreItem FindStoreItemById(int id)
        {
            if(id < 0)
            {
                throw new InvalidIdException(id);
            }
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
