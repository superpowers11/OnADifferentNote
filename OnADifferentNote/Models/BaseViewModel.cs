using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnADifferentNote.Models
{
    public class BaseViewModel : IBaseViewModel //colon means "implements" here w/ interface
    {
        public ProductViewModel FeaturedProduct { get; set; }
        public ShoppingCartViewModel ShoppingCart { get; set; }
        
    }
}