using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class ProductDetailsTable
    {
        public ProductDetailsTable()
        {
            CartTables = new HashSet<CartTable>();
            OrderDetailTables = new HashSet<OrderDetailTable>();
            ProductCompareTables = new HashSet<ProductCompareTable>();
        }

        public int ProductDetailsId { get; set; }
        public int ProductHeaderId { get; set; }
        public int ColorTypeId { get; set; }
        public int SizeTypeByLevelId { get; set; }
        public int UnitId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string BarCode { get; set; } = null!;
        public int StatusId { get; set; }
        public int CreatedByUserId { get; set; }
        public int UpdateByUserId { get; set; }

        public virtual ColorTypeTable ColorType { get; set; } = null!;
        public virtual StatusTable CreatedByUser { get; set; } = null!;
        public virtual UserTable CreatedByUserNavigation { get; set; } = null!;
        public virtual ProductHeaderTable ProductHeader { get; set; } = null!;
        public virtual SizeTypeByLeveTable SizeTypeByLevel { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
        public virtual UnitTable Unit { get; set; } = null!;
        public virtual StatusTable UpdateByUser { get; set; } = null!;
        public virtual UserTable UpdateByUserNavigation { get; set; } = null!;
        public virtual ICollection<CartTable> CartTables { get; set; }
        public virtual ICollection<OrderDetailTable> OrderDetailTables { get; set; }
        public virtual ICollection<ProductCompareTable> ProductCompareTables { get; set; }
    }
}
