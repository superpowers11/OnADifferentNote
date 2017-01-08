
namespace OnADifferentNote.Services
{
    public interface IPromoService
    {
        Promotion GetPromoByProductAndZip(int productId, string zipCode);
    }
}