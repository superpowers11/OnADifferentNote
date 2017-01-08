
namespace OnADifferentNote.Models
{
    public class ProductViewModel : BaseViewModel
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public bool isFeaturedProduct { get; set; }
        public double ProductSalePrice { get; set; }
        public int quantity { get; set; }
    }
}