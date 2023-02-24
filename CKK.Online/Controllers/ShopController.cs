using CKK.DB.Interfaces;
using CKK.DB.UOW;
using CKK.Online.Models;
using CKK.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CKK.Online.Controllers
{
    public class ShopController : Controller
    {
        public UnitOfWork StoreUOW { get; set; }
        public Store StoreFront { get; set; }
        public CustomerCart ShoppingCart { get; set; }
        public ShopController(IUnitOfWork UOW)
        {
            StoreUOW = (UnitOfWork)UOW;
            StoreFront = new Store(StoreUOW);
            ShoppingCart = new CustomerCart();
        }
        [HttpGet]
        [Route("/Shop/ShoppingCart")]
        public IActionResult Index()
        {
            if (StoreUOW.Customer.ShoppingCartId == 0)
            {
                StoreUOW.Customer.ShoppingCartId = StoreUOW.ShoppingCarts.GetExistingCartIdForExample().Result;
            }
            StoreFront.RefreshCart(ShoppingCart);
            return View("ShoppingCart", ShoppingCart);
        }

        [HttpGet]
        [Route("/Shop")]
        public IActionResult Manage()
        {
            return View("StoreFront", StoreFront);
        }

        [HttpGet]
        [Route("/Shop/ShoppingCart/Order")]
        public IActionResult CheckOutCustomer()
        {
            //Get order info
            var orderNumber = StoreUOW.CompleteCheckout();
            //Update quantities of products in inventory took place in UOW CompleteCheckout

            //Display Confirmation

            var model = new CheckoutConfirmation(orderNumber);
            return View("Checkout", model);

        }

        [HttpGet]
        [Route("Shop/Add/{productId}")]
        public IActionResult Add([FromRoute] int productId, [FromQuery] int quantity)
        {
            var product = StoreUOW.Products.GetbyId(productId).Result;
            var itemAdded = StoreUOW.AddItemToCart(new Product { Id = product.Id,
            Name = product.Name, Price = product.Price, Quantity = quantity});
            ShoppingCart.Total = StoreUOW.ShoppingCarts.GetTotal(StoreUOW.Customer.ShoppingCartId).Result;
            return Ok(ShoppingCart.Total);
        }
    }
}
