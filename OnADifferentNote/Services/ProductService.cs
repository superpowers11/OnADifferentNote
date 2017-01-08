using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnADifferentNote.Repositories;

namespace OnADifferentNote.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Return the current featured prouct
        public Product GetFeaturedProduct()
        {
            var featuredProduct = _unitOfWork.ProductRepository.Where(p => p.FeaturedProduct == true).FirstOrDefault();

            return featuredProduct;
        }
    }

}