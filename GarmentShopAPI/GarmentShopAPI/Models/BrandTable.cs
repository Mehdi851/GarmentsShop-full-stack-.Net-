using System;
using System.Collections.Generic;

namespace GarmentShopAPI.Models
{
    public partial class BrandTable
    {
        public BrandTable()
        {
            ProductHeaderTables = new HashSet<ProductHeaderTable>();
        }

        public int BrandId { get; set; }
        public string BrandTitle { get; set; } = null!;
        public string? BrandLogo { get; set; }
        public string? BrandImage { get; set; }
        public int StatusId { get; set; }

        public virtual StatusTable Status { get; set; } = null!;
        public virtual ICollection<ProductHeaderTable> ProductHeaderTables { get; set; }
    }
}
