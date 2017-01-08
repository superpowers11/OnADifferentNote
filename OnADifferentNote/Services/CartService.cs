using System;
using System.Linq;
using OnADifferentNote.Repositories;

namespace OnADifferentNote.Services
{
    public class CartService : ICartService
    {
        private IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        } 

        public Cart GetCart(int ownerId)
        {
            var cart = _unitOfWork.CartRepository.Where(c => c.OwnerId == ownerId).FirstOrDefault();
            if (cart != null)
            {
                return cart;
            }
            else
            {
                cart = CreateCart(ownerId);
                return cart;
            }
        }

        public Cart CreateCart(int ownerId, string zipCode = null)
        {
            var user = _unitOfWork.UserRepository.FirstOrDefault(p => p.UserId == ownerId);
            var cart = new Cart();
            cart.CartDateCreated = DateTime.Today;

            if (zipCode != null)
            {
                cart.ZipCode = zipCode;
            }
            else { cart.ZipCode = ""; }
            cart.OwnerId = ownerId;
            cart.CartStatus = "new";
            cart.User = user;
          
            
            _unitOfWork.CartRepository.Add(cart);
            _unitOfWork.Save();
            return cart;
        }

        public void UpdateCart(int cartId, int productId, int quantity = 1)
        {
            var cart = _unitOfWork.CartRepository.Where(c => c.CartId == cartId).FirstOrDefault();
            if (cart == null)
            {
                Console.WriteLine("No such cart exists.");
            }
            else
            {
                var product = cart.CartProducts.Where(p => p.ProductId == productId).FirstOrDefault();
                if (quantity == -1)
                {
                    if (product != null)
                    {
                        cart.CartProducts.Remove(product);
                        _unitOfWork.Save();
                    }
                    else
                    {
                        Console.WriteLine("No such item in cart.");
                    }
                }
                else
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        var productToAdd = new CartProduct();
                        productToAdd.ProductId = productId;
                        cart.CartProducts.Add(productToAdd);
                        _unitOfWork.Save();
                    }
                }
            }
        }
    }
}