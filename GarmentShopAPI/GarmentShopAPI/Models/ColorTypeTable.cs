using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class ColorTypeTable
    {
        public ColorTypeTable()
        {
            ProductDetailsTables = new HashSet<ProductDetailsTable>();
        }

        public int ColorTypeId { get; set; }
        public string ColorTitle { get; set; } = null!;
        public string ColorCode { get; set; } = null!;
        public int StatusId { get; set; }

        public virtual StatusTable Status { get; set; } = null!;
        public virtual ICollection<ProductDetailsTable> ProductDetailsTables { get; set; }
    }
}
