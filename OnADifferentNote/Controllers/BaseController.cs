using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnADifferentNote.Models;
using OnADifferentNote.Services;
using OnADifferentNote.Repositories;

namespace OnADifferentNote.Controllers
{
    public class BaseController : Controller
    {
        public IProductService ProductService;
        public IPromoService PromoService;
        public IUserService UserService;
        public ICartService CartService;

        public BaseController()
        {
            var _unitOfWork = new UnitOfWork();
            ProductService = new ProductService(_unitOfWork);
            PromoService = new PromoService(_unitOfWork);
            UserService = new UserService(_unitOfWork);
            CartService = new CartService(_unitOfWork);
        }
        public BaseController(IPromoService promoService, IProductService productService,
            IUserService userService)
        {
            ProductService = productService;
            PromoService = promoService;
            UserService = userService;
        }

        public ProductViewModel GetProductViewModel(Product product)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.ProductName = product.ProductName;
            productViewModel.ProductId = product.ProductId;
            productViewModel.ProductPrice = product.Price;
            productViewModel.ProductImageUrl = product.ProductImageUrl;

            int productId = product.ProductId;
            var zipCookie = Request.Cookies["Zip Code Cookie"];
            if (zipCookie != null)
            {
                string zipCode = zipCookie.Value;
                Promotion productPromotion = PromoService.GetPromoByProductAndZip(productId, zipCode);
                //then do all the stuff below, get the promo based on zip code and product
                if (productPromotion != null)
                {
                    if (productPromotion.SalePrice != default(double))
                    {
                        productViewModel.ProductSalePrice = productPromotion.SalePrice.Value;

                        return productViewModel;
                    }
                    return productViewModel;
                }
            }
            return productViewModel;
        }

    }
}