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
        public ShopController(IUnitOfWork UOW)
        {
            StoreUOW = (UnitOfWork)UOW;
        }
        [HttpGet]
        [Route("/Shop/ShoppingCart")]
        public IActionResult Index()
        {
            var model = new Store(StoreUOW);
            model.ShoppingCart.CartItems = model.StoreFront.ShoppingCarts.GetProducts(model.StoreFront.Customer.ShoppingCartId);
            model.ShoppingCart.Total = model.StoreFront.ShoppingCarts.GetTotal(model.StoreFront.Customer.ShoppingCartId);
            return View("ShoppingCart", model.ShoppingCart);
        }

        [HttpGet]
        [Route("/Shop")]
        public IActionResult Manage()
        {
            var model = new Store(StoreUOW);
            return View("StoreFront", model);
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
            var product = StoreUOW.Products.GetbyId(productId);
            var itemAdded = StoreUOW.AddItemToCart(new Product { Id = product.Id,
            Name = product.Name, Price = product.Price, Quantity = product.Quantity});
            var total = StoreUOW.ShoppingCarts.GetTotal(StoreUOW.Customer.ShoppingCartId);
            return Ok(total);
        }
    }
}
