using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class UnitTable
    {
        public UnitTable()
        {
            ProductDetailsTables = new HashSet<ProductDetailsTable>();
        }

        public int UnitId { get; set; }
        public string UnitTitle { get; set; } = null!;

        public virtual ICollection<ProductDetailsTable> ProductDetailsTables { get; set; }
    }
}
