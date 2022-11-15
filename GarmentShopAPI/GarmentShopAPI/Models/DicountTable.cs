using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class DicountTable
    {
        public DicountTable()
        {
            CartTables = new HashSet<CartTable>();
            OrderDetailTables = new HashSet<OrderDetailTable>();
        }

        public int DiscountId { get; set; }
        public string DiscountTitle { get; set; } = null!;
        public string CouponCode { get; set; } = null!;
        public string DiscountDescription { get; set; } = null!;
        public double DiscountPercent { get; set; }
        public int StatusId { get; set; }
        public int CreatedByUserId { get; set; }
        public int UpdatedByUserId { get; set; }

        public virtual UserTable CreatedByUser { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
        public virtual UserTable UpdatedByUser { get; set; } = null!;
        public virtual ICollection<CartTable> CartTables { get; set; }
        public virtual ICollection<OrderDetailTable> OrderDetailTables { get; set; }
    }
}
