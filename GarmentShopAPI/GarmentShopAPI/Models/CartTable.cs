using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class CartTable
    {
        public int CartId { get; set; }
        public int ProductDetailsId { get; set; }
        public int Quantity { get; set; }
        public int DiscountId { get; set; }
        public int UniqueNo { get; set; }
        public double UnitPrice { get; set; }

        public virtual DicountTable Discount { get; set; } = null!;
        public virtual ProductDetailsTable ProductDetails { get; set; } = null!;
    }
}
