using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnADifferentNote.Services
{
    public interface ICartService
    {
        Cart GetCart(int ownerId);
        Cart CreateCart(int ownerId, string zipCode = null);
        void UpdateCart(int cartId, int productId, int quantity);
    }
}