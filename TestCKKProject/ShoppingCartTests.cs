using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestCKKProject
{
    public class ShoppingCartTests
    {
        CKK.Logic.Models.Customer customerAlpha = new CKK.Logic.Models.Customer();
        CKK.Logic.Models.Customer customerBravo = new CKK.Logic.Models.Customer();
        CKK.Logic.Models.Customer customerCharlie = new CKK.Logic.Models.Customer();

        CKK.Logic.Models.ShoppingCart shoppingCartFull;
        CKK.Logic.Models.ShoppingCart shoppingCartEmpty;
        CKK.Logic.Models.ShoppingCart shoppingCartTwoItems;

        CKK.Logic.Models.Product productA = new CKK.Logic.Models.Product(); //123456 $2.43 
        CKK.Logic.Models.Product productB = new CKK.Logic.Models.Product(); //548769 $1.16
        CKK.Logic.Models.Product productC = new CKK.Logic.Models.Product(); //813442 $0.36
        CKK.Logic.Models.Product productD = new CKK.Logic.Models.Product(); //664211 $111.25
        CKK.Logic.Models.Product productE = new CKK.Logic.Models.Product(); //552143 $24.98

        //preps the fields, then tests the carts to make sure items were correctly added
        [Fact]
        public void PrepTests()
        {
            customerAlpha.SetId(111111);
            customerBravo.SetId(222222);
            customerCharlie.SetId(333333);
            shoppingCartFull = new CKK.Logic.Models.ShoppingCart(customerAlpha);
            shoppingCartEmpty = new CKK.Logic.Models.ShoppingCart(customerBravo);
            shoppingCartTwoItems = new CKK.Logic.Models.ShoppingCart(customerCharlie);
            productA.SetId(123456);
            productA.SetPrice((decimal)2.43);
            productB.SetId(548769);
            productB.SetPrice((decimal)1.16);
            productC.SetId(813442);
            productC.SetPrice((decimal)0.36);
            productD.SetId(664211);
            productD.SetPrice((decimal)111.25);
            productE.SetId(552143);
            productE.SetPrice((decimal)24.98);

            shoppingCartFull.AddProduct(productA, 2);
            shoppingCartFull.AddProduct(productC);
            shoppingCartFull.AddProduct(productD);
            shoppingCartFull.AddProduct(productB);

            shoppingCartTwoItems.AddProduct(productE);
            shoppingCartTwoItems.AddProduct(productB);
            shoppingCartTwoItems.AddProduct(productE);
            shoppingCartTwoItems.AddProduct(productE);

            //added in preparation for total test
            shoppingCartEmpty.AddProduct(productA, 2);
            shoppingCartEmpty.AddProduct(productB, 8);
        }
        //makes sure that the proper quantities were entered and that product b wasn't added because the cart was full
        [Fact]
        public void ShoppingCartFullTest()
        {

            PrepTests();
            Assert.True(shoppingCartFull.GetProduct(1).GetQuantity() + shoppingCartFull.GetProduct(2).GetQuantity() +
                shoppingCartFull.GetProduct(3).GetQuantity() == 4 && shoppingCartFull.GetProductById(productB.GetId()) == null);
        }

        //makes sure that items are added to like items and not just in empty spaces
        [Fact]
        public void ShoppingcartTwoItemsTest()
        {
            PrepTests();
            Assert.True(shoppingCartTwoItems.GetProduct(1).GetProduct().GetId() == productE.GetId() && shoppingCartTwoItems.GetProduct(2).GetProduct().GetId() == productB.GetId()
                && shoppingCartTwoItems.GetProduct(3) == null && shoppingCartTwoItems.GetProduct(1).GetQuantity() == 3);
        }


        [Fact]
        public void TestRemoveProductShoppingCartFull()
        {
            PrepTests();
            shoppingCartFull.RemoveProduct(productA, 1);
            shoppingCartFull.RemoveProduct(productC, 1);
            shoppingCartFull.RemoveProduct(productD, 1);

            Assert.True(shoppingCartFull.GetProduct(1).GetQuantity() == 1 && shoppingCartFull.GetProduct(2) == null);
        }

        [Fact]
        public void TestRemoveProductShoppingCartTwoItems()
        {
            PrepTests();
            shoppingCartTwoItems.RemoveProduct(productE, 1);
            shoppingCartTwoItems.RemoveProduct(productB, 2);

            Assert.True(shoppingCartTwoItems.GetProductById(productB.GetId()) == null && shoppingCartTwoItems.GetProductById(productE.GetId()).GetQuantity() == 2);
        }

        [Fact]
        public void TestGetTotal()
        {
            PrepTests();
            Assert.True(shoppingCartFull.GetTotal() == (productA.GetPrice() * 2 + productC.GetPrice() + productD.GetPrice()) &&
                shoppingCartTwoItems.GetTotal() == productE.GetPrice() * 3 + productB.GetPrice() &&
                shoppingCartEmpty.GetTotal() == productA.GetPrice() * 2 + productB.GetPrice() * 8);
        }

        [Fact]
        public void TestEmptyCart()
        {
            PrepTests();
            shoppingCartEmpty.EmptyCart();

            Assert.True(shoppingCartEmpty.GetProduct(1) == null);
        }
    }
}
