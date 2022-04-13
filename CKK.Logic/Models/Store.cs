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
        private Product _product1;
        private Product _product2;
        private Product _product3;

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

        public void AddStoreItem(Product prod)
        {
            if (_product1 == null)
            {
                _product1 = prod;
            }
            else if(_product2 == null)
            {
                _product2 = prod;
            }
            else if(_product3 == null)
            {
                _product3 = prod;
            }
        }

        public void RemoveStoreItem(int productNumber)
        {
            switch (productNumber)
            {
                case 1:
                    _product1 = null;
                    break;
                case 2:
                    _product2 = null;
                    break;
                case 3:
                    _product3 = null;
                    break;
                default:
                    break;
            }
        }

        public Product GetStoreItem(int productNumber)
        {
            switch (productNumber)
            {
                case 1:
                    return _product1;
                case 2:
                    return _product2;
                case 3:
                    return _product3;
                default:
                    return null;
            }
        }

        public Product FindStoreItemById(int id)
        {
            List<Product> thisStoresItems = new List<Product>{ _product1, _product2, _product3 };
            foreach(Product prod in thisStoresItems)
            {
                if(id == prod.GetId())
                {
                    return prod;
                }
            }

            return null;

        }
    }
}
