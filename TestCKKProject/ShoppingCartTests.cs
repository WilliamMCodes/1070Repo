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
        CKK.Logic.Models.Customer customerAlpha = new CKK.Logic.Models.Customer(1,"Alpha", "here");
        CKK.Logic.Models.Customer customerBravo = new CKK.Logic.Models.Customer(2, "Bravo", "there");
        CKK.Logic.Models.Customer customerCharlie = new CKK.Logic.Models.Customer(3, "Charlie", "and back again");

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
            customerAlpha.Id = 111111;
            customerBravo.Id = 222222;
            customerCharlie.Id = 333333;
            shoppingCartFull = new CKK.Logic.Models.ShoppingCart(customerAlpha);
            shoppingCartEmpty = new CKK.Logic.Models.ShoppingCart(customerBravo);
            shoppingCartTwoItems = new CKK.Logic.Models.ShoppingCart(customerCharlie);
            productA.Id = 123456;
            productA.Price = 2.43M;
            productB.Id = 548769;
            productB.Price = 1.16M;
            productC.Id = 813442;
            productC.Price = 0.36M;
            productD.Id = 664211;
            productD.Price = 111.25M;
            productE.Id = 552143;
            productE.Price = 24.98M;

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
        public void ShoppingCartTest()
        {
            PrepTests();
            Assert.True(shoppingCartFull.Products[0].Quantity == 2 && shoppingCartFull.Products.Count == 4);
        }

        //makes sure that items are added to like items and not just in empty spaces
        [Fact]
        public void ShoppingcartTwoItemsTest()
        {
            PrepTests();
            Assert.True(shoppingCartTwoItems.Products[0].Product.Id == productE.Id && shoppingCartTwoItems.Products[1].Product.Id == productB.Id
                && shoppingCartTwoItems.Products[2] == null && shoppingCartTwoItems.Products[0].Quantity == 3);
        }


        [Fact]
        public void TestRemoveProductShoppingCartFull()
        {
            PrepTests();
            shoppingCartFull.RemoveProduct(productA.Id, 1);
            shoppingCartFull.RemoveProduct(productC.Id, 1);
            shoppingCartFull.RemoveProduct(productD.Id, 1);

            Assert.True(shoppingCartFull.Products[0].Quantity == 1 && shoppingCartFull.Products[1] == null);
        }

        [Fact]
        public void TestRemoveProductShoppingCartTwoItems()
        {
            PrepTests();
            shoppingCartTwoItems.RemoveProduct(productE.Id, 1);
            shoppingCartTwoItems.RemoveProduct(productB.Id, 2);

            Assert.True(shoppingCartTwoItems.GetProductById(productB.Id) == null && shoppingCartTwoItems.GetProductById(productE.Id).Quantity == 2);
        }

        [Fact]
        public void TestGetTotal()
        {
            PrepTests();
            Assert.True(shoppingCartFull.GetTotal() == (productA.Price * 2 + productC.Price + productD.Price) &&
                shoppingCartTwoItems.GetTotal() == productE.Price * 3 + productB.Price &&
                shoppingCartEmpty.GetTotal() == productA.Price * 2 + productB.Price * 8);
        }

        [Fact]
        public void TestEmptyCart()
        {
            PrepTests();
            shoppingCartEmpty.EmptyCart();

            Assert.True(shoppingCartEmpty.Products.Count == 0);
        }
    }
}
