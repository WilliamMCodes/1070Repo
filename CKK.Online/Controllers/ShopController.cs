using CKK.DB.Interfaces;
using CKK.DB.UOW;
using CKK.Online.Models;
using CKK.Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace CKK.Online.Controllers
{
    public class ShopController : Controller
    {
        public UnitOfWork StoreUOW { get; set; }
        public ShopController(UnitOfWork UOW)
        {
            StoreUOW = UOW;
        }
        [HttpGet]
        [Route("/Shop/ShoppingCart")]
        public IActionResult Index()
        {
            var model = new Store(StoreUOW);
            return View("ShoppingCart", model.ShoppingCart);
        }

        [HttpGet]
        [Route("/Shop")]
        public IActionResult Manage()
        {
            var model = new Store(StoreUOW);
            return View("StoreFront", model);
        }

        public IActionResult CheckOutCustomer([FromQuery] string orderId)
        {
            //Get order info

            //Update quantities of products in inventory

            //For the assignment we just delete or clear 

            var model = new CheckoutConfirmation(orderId);
            return View("Checkout", model);

        }

        [HttpGet]
        [Route("Shop/ShoppingCart/Add/{productId}")]
        public IActionResult Add([FromRoute] int productId, [FromQuery] int quantity)
        {
            var product = StoreUOW.Products.GetbyId(productId);
            var itemAdded = StoreUOW.ShoppingCarts.AddToCart(StoreUOW.Customer.ShoppingCartId, new Product { Id = product.Id,
            Name = product.Name, Price = product.Price, Quantity = product.Quantity});
            var total = StoreUOW.ShoppingCarts.GetTotal(StoreUOW.Customer.ShoppingCartId);
            return Ok(total);
        }
    }
}
