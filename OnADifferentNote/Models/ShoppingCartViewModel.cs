using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnADifferentNote.Models
{
    public class ShoppingCartViewModel : BaseViewModel
    {
        public DateTime DateCreated { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public double Total { get; set; }
        public double Tax { get; set; }
        
    }
}