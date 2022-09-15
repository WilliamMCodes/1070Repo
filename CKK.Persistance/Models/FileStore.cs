using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace CKK.Persistance.Models
{
    public class FileStore: Logic.Interfaces.IStore, Persistance.Intefaces.ILoadable, Persistance.Intefaces.ISavable
    {
        private List<Logic.Models.StoreItem> Items;
        public readonly string FilePath;
        private int IdCounter;

        public FileStore()
        {
            FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar +
                "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";
            if (File.Exists(FilePath))
            {
                Load();
            }
        }

        public StoreItem AddStoreItem(Product prod, int quantity = 1)
        {
            if (quantity > 0)
            {
                StoreItem selectedItem = FindStoreItemById(prod.Id);
                if (selectedItem != null)
                {
                    selectedItem.Quantity += quantity;
                }
                else
                {
                    selectedItem = new StoreItem(prod, quantity);
                    Items.Add(selectedItem);
                }
                return selectedItem;
            }
            else
            {
                throw new Logic.Exceptions.InventoryItemStockTooLowException(quantity);
            }
            
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if(quantity < 0)
            {
                throw new ArgumentOutOfRangeException("quantity", $"{quantity} is not a valid amount to reduce inventory by.");
            }
            else
            {
                StoreItem selectedItem = FindStoreItemById(id);
                if(selectedItem == null)
                {
                    throw new Logic.Exceptions.ProductDoesNotExistException(id);
                }
                else
                {
                    if(quantity <= selectedItem.Quantity)
                    {
                        selectedItem.Quantity = selectedItem.Quantity - quantity;
                    }
                    else
                    {
                        selectedItem.Quantity = 0;
                    }
                    return selectedItem;
                }
            }
        }

        public StoreItem FindStoreItemById(int id)
        {
            if(id < 0)
            {
                throw new Logic.Exceptions.InvalidIdException(id);
            }
            var selectedItem =
                from storeItem in Items
                where storeItem.Product.Id == id
                select storeItem;
            if(selectedItem.Count() == 1)
            {
                return selectedItem.Single();
            }
            else if (selectedItem.Any())
            {
                throw new Exception("Duplicate Item Numbers Found.");
            }
            else
            {
                return null;
            }
        }

        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }

        public void Load()
        {
            FileStream fileStream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Read);
            BinaryFormatter reader = new BinaryFormatter();
            List<StoreItem> inventory = (List<StoreItem>)reader.Deserialize(fileStream);
            Items = inventory;
        }

        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            CreatePath();
            FileStream fileStream = new FileStream(FilePath, FileMode.Append);
            formatter.Serialize(fileStream, Items);
        }

        private void CreatePath()
        {
            File.Create(FilePath);
        }
    }
}
