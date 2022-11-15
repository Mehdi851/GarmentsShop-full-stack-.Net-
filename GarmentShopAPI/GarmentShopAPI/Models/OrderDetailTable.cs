using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class OrderDetailTable
    {
        public int OrderDetailsId { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductDetailId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int DiscountId { get; set; }

        public virtual DicountTable Discount { get; set; } = null!;
        public virtual OrderHeaderTable OrderHeader { get; set; } = null!;
        public virtual ProductDetailsTable ProductDetail { get; set; } = null!;
    }
}
