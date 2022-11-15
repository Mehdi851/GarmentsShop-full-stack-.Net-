using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class SizeTypeByLeveTable
    {
        public SizeTypeByLeveTable()
        {
            ProductDetailsTables = new HashSet<ProductDetailsTable>();
        }

        public int SizeTypeByLeveId { get; set; }
        public int SizeTypeId { get; set; }
        public int SizeLevelId { get; set; }
        public string SizeLevelValue { get; set; } = null!;
        public int StatusId { get; set; }
        public int GenderId { get; set; }

        public virtual GenderTable Gender { get; set; } = null!;
        public virtual SizeLevelTable SizeLevel { get; set; } = null!;
        public virtual SizeTypeTable SizeType { get; set; } = null!;
        public virtual StatusTable Status { get; set; } = null!;
        public virtual ICollection<ProductDetailsTable> ProductDetailsTables { get; set; }
    }
}
