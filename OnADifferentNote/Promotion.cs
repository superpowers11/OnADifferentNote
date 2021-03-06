//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnADifferentNote
{
    using System;
    using System.Collections.Generic;
    
    public partial class Promotion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Promotion()
        {
            this.CartPromotions = new HashSet<CartPromotion>();
        }
    
        public int PromotionId { get; set; }
        public string PromoName { get; set; }
        public string PromoDescription { get; set; }
        public System.DateTime PromoStart { get; set; }
        public System.DateTime PromoEnd { get; set; }
        public System.DateTime PromoDateCreated { get; set; }
        public Nullable<double> SalePrice { get; set; }
        public Nullable<double> OverallDiscount { get; set; }
        public string ZipCode { get; set; }
        public string PromoType { get; set; }
        public int ProductId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartPromotion> CartPromotions { get; set; }
        public virtual Product Product { get; set; }
    }
}
