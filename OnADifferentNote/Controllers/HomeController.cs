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
    public class HomeController : BaseController
    {
        public HomeController()
        {

        }

        public HomeController(IPromoService promoService, IProductService productService,
            IUserService userService) :base (promoService, productService, userService)
        {
        }

        public ActionResult Index()
        {
            HomeIndexViewModel viewModel = new HomeIndexViewModel();
            Product featuredProduct = ProductService.GetFeaturedProduct();
            if (featuredProduct == null)
            {
                return View(viewModel);
            }
            else
            {
                ProductViewModel productViewModel = GetProductViewModel(featuredProduct);
                productViewModel.isFeaturedProduct = true;
                
                viewModel.FeaturedProduct = productViewModel;
                return View(viewModel);
            }
        }

        //Create the cookie to hold user's zip code value
        private void CreateNewCookie(string value, string cookieName)
        {
            HttpCookie newCookie = new HttpCookie(cookieName);
            newCookie.Value = value;
            Response.Cookies.Add(newCookie);
        }

        //When a user enters a zip code, update the page accordingly
        public JsonResult UpdateZip(string zipCode)
        {
            CreateNewCookie(zipCode, "Zip Code Cookie");

            var featuredProduct = ProductService.GetFeaturedProduct();
            var promo = PromoService.GetPromoByProductAndZip(featuredProduct.ProductId, zipCode);
            //Note that the next two lines are similar to my GetSalePrice in PromoService
            //var promo = featuredProduct.Promotions.FirstOrDefault(p => p.promoStartDate <= DateTime.Now 
            //&& p.promoEndDate >= DateTime.Now && Convert.ToString(p.promoZipCode) == zipCode);
           
            //Note that the next two lines are similar to my GetSalePrice in PromoService
            //var promo = featuredProduct.Promotions.FirstOrDefault(p => p.promoStartDate <= DateTime.Now 
            //&& p.promoEndDate >= DateTime.Now && Convert.ToString(p.promoZipCode) == zipCode);

            double salePrice = 0;
            if (promo != null && promo.SalePrice.HasValue)
            {
                salePrice = promo.SalePrice.Value;
                ProductViewModel productViewModel = GetProductViewModel(featuredProduct);
                productViewModel.ProductSalePrice = salePrice;
            }
            var result = new {status = "Udpated", promoSalePrice = salePrice};
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Add a new user
        public JsonResult NewUserSignUp(string email, string username, string password)
        {
            User newUser = UserService.CreateUser(email, username, password);
            var result = new { status = "Added", user = username };
            int userId = newUser.UserId;
            CreateNewCookie(userId.ToString(), "UserID");
            CreateNewCookie(username, "Username");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
 
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}