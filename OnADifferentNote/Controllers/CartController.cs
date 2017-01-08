using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnADifferentNote.Services;
using OnADifferentNote.Models;
using OnADifferentNote.Repositories;

namespace OnADifferentNote.Controllers
{
    public class CartController : BaseController
    {
        
        public CartController()
        {
            
        }

        public CartController(IPromoService promoService, IProductService productService,
            IUserService userService) :base (promoService, productService, userService)
        {
        }
         
        public ActionResult Index()
        {
            Cart cart;
            ShoppingCartViewModel cartViewModel = new ShoppingCartViewModel();
            cartViewModel.Products = new List<ProductViewModel>();
            var userIdCookie = Request.Cookies["User ID"];
            if (userIdCookie != null)
            {
                string userIdString = userIdCookie.Value;
                int userId;
                bool parsed = int.TryParse(userIdString, out userId);
                cart = CartService.GetCart(userId);
                cartViewModel.DateCreated = DateTime.Today;

                foreach (var item in cart.CartProducts.ToList())
                {
                    ProductViewModel product = GetProductViewModel(item.Product);
                    cartViewModel.Products.Add(product);
                    product.quantity = product.quantity + 1;
                    double priceToAdd;
                    if (product.ProductSalePrice == default(double))
                    {
                        priceToAdd = product.ProductPrice;

                    }
                    else
                    {
                        priceToAdd = product.ProductSalePrice;
                    }
                    cartViewModel.Total = cartViewModel.Total + priceToAdd;
                    cartViewModel.Tax = Math.Round((cartViewModel.Tax + (.06 * cartViewModel.Total)),2);
                }
            }

            return View(cartViewModel);
        }

        // Add an item to the shopping cart
        // If a current user exists, add to their cart
        // If no current user, create a user and then add to their cart 
        public JsonResult AddToCart(int productId)
        {
            int userId;
            int cartId;
            var userIdCookie = Request.Cookies["User ID"];
            var cartIdCookie = Request.Cookies["Cart ID"];
            if (userIdCookie != null)
            {
                string userIdString = userIdCookie.Value;
                bool parsed = int.TryParse(userIdString, out userId);
            }
            else
            {
                var user = UserService.CreateUser();
                userId = user.UserId;

                HttpCookie userCookie = new HttpCookie("User ID");
                userCookie.Value = userId.ToString();
                Response.Cookies.Add(userCookie);
            }

            if (cartIdCookie != null)
            {
                string cartIdString = cartIdCookie.Value;
                bool p = int.TryParse(cartIdString, out cartId);
            }
            else
            {
                var cart = CartService.CreateCart(userId);
                cartId = cart.CartId;
                HttpCookie cartCookie = new HttpCookie("Cart ID");
                cartCookie.Value = cartId.ToString();
                Response.Cookies.Add(cartCookie);
            }

            CartService.UpdateCart(cartId, productId, 1);

            var result = new { status = "New", cartId = cartId };
            return Json(result, JsonRequestBehavior.AllowGet); 
        }

        public JsonResult RemoveFromCart(int productId)
        {
            var cartCookie = Request.Cookies["Cart ID"];
            var cartIdString = cartCookie.Value;
            int cartId;
            bool parsed = int.TryParse(cartIdString, out cartId);
            CartService.UpdateCart(cartId, productId, -1);
            var result = new { status = "Success" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}