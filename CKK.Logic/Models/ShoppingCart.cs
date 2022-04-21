using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer _customer;
        private ShoppingCartItem _product1;
        private ShoppingCartItem _product2;
        private ShoppingCartItem _product3;

        public ShoppingCart(Customer cust)
        {
            _customer = cust;
        }

        public int GetCustomerId()
        {
            return _customer.GetId();
        }

        public ShoppingCartItem  AddProduct(Product prod, int quantity)
        {
            for(int i = 1; i <= 3; i++)
            {
                if(GetProduct(i) != null)
                {
                    if(GetProduct(i).GetProduct().GetId() == prod.GetId())
                    {
                        GetProduct(i).SetQuantity(GetProduct(i).GetQuantity() + quantity);
                        return GetProduct(i);
                    }
                }
                else if(GetProduct(i) == null)
                {
                    switch (i)
                    {
                        case 1:
                            _product1 = new ShoppingCartItem(prod, quantity);
                            return _product1;
                        case 2:
                            _product2 = new ShoppingCartItem(prod, quantity);
                            return _product2;
                        case 3:
                            _product3 = new ShoppingCartItem(prod, quantity);
                            return _product3;
                        default:
                            break;
                    }
                }
            }

            return null;
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (GetProduct(i) != null)
                {
                    if (GetProduct(i).GetProduct().GetId() == prod.GetId())
                    {
                        GetProduct(i).SetQuantity(GetProduct(i).GetQuantity() + 1);
                        return GetProduct(i);
                    }
                }
                else if (GetProduct(i) == null)
                {
                    switch (i)
                    {
                        case 1:
                            _product1 = new ShoppingCartItem(prod, 1);
                            return _product1;
                        case 2:
                            _product2 = new ShoppingCartItem(prod, 1);
                            return _product2;
                        case 3:
                            _product3 = new ShoppingCartItem(prod, 1);
                            return _product3;
                        default:
                            break; ;
                    }
                }
            }

            return null;
        }

        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            if(GetProductById(prod.GetId()) != null)
            {
                if (GetProductById(prod.GetId()).GetQuantity() > quantity)
                {
                    GetProductById(prod.GetId()).SetQuantity(GetProductById(prod.GetId()).GetQuantity() - quantity);
                    return GetProductById(prod.GetId());
                }
                else
                {
                    if(GetProductById(prod.GetId()) == _product1)
                    {
                        _product1 = null;
                        return null;
                    }
                    else if(GetProductById(prod.GetId()) == _product2)
                    {
                        _product2 = null;
                        return null;
                    }
                    else
                    {
                        _product3 = null;
                        return null;
                    }
                }
            }

            return null;
        }

        public void EmptyCart()
        {
            _product1 = null;
            _product2 = null;
            _product3 = null;
        }

        public ShoppingCartItem GetProductById(int id)
        {
            for(int i = 1; i <= 3; i++)
            {
                if (GetProduct(i) != null)
                {
                    if (GetProduct(i).GetProduct().GetId() == id)
                    {
                        return GetProduct(i);
                    }
                }
            }
            return null;
        }

        public decimal GetTotal()
        {
            decimal total = (decimal)0.0;
            for(int i = 1; i <= 3; i++)
            {
                if(GetProduct(i) != null)
                {
                    total += GetProduct(i).GetProduct().GetPrice() * GetProduct(i).GetQuantity();
                }
            }
            return total;
        }

        public ShoppingCartItem GetProduct(int productNum)
        {
            switch(productNum)
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
    }
}
