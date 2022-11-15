using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class ProductCompareTable
    {
        public int ProductCompareId { get; set; }
        public int CompareUserId { get; set; }
        public int ProductDetailId { get; set; }

        public virtual UserTable CompareUser { get; set; } = null!;
        public virtual ProductDetailsTable ProductDetail { get; set; } = null!;
    }
}
