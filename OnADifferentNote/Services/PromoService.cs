using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnADifferentNote.Repositories;

namespace OnADifferentNote.Services
{
    public class PromoService : IPromoService
    {
        private IUnitOfWork _unitOfWork;

        public PromoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        //Return sale price of a product, based on zip code
        public Promotion GetPromoByProductAndZip(int productId, string zipCode)
        {
             return _unitOfWork.PromoRepository.Where(p => p.ProductId == productId && p.ZipCode == zipCode).FirstOrDefault();
        }
    }
}