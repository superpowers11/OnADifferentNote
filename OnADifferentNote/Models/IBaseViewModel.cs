using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnADifferentNote.Models
{
    public interface IBaseViewModel
    {
        ProductViewModel FeaturedProduct { get; set; }
        ShoppingCartViewModel ShoppingCart { get; set; }
    }
}